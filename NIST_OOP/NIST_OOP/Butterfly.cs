using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NIST_OOP
{
    //fft
    public static class Butterfly
    {
        public const double SinglePi = Math.PI;
        public const double DoublePi = 2 * Math.PI;

        public static Complex[] DecimationInTime(Complex[] frame, bool direct)
        {
            if (frame.Length == 1) return frame;
            var frameHalfSize = frame.Length >> 1;
            var frameFullSize = frame.Length;

            var frameOdd = new Complex[frameHalfSize];
            var frameEven = new Complex[frameHalfSize];
            for (var i = 0; i < frameHalfSize; i++)
            {
                var j = i << 1; // i = 2*j;
                frameOdd[i] = frame[j + 1];
                frameEven[i] = frame[j];
            }

            var spectrumOdd = DecimationInTime(frameOdd, direct);
            var spectrumEven = DecimationInTime(frameEven, direct);

            var arg = direct ? -DoublePi / frameFullSize : DoublePi / frameFullSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[frameFullSize];

            for (var j = 0; j < frameHalfSize; j++)
            {
                spectrum[j] = spectrumEven[j] + omega * spectrumOdd[j];
                spectrum[j + frameHalfSize] = spectrumEven[j] - omega * spectrumOdd[j];
                omega *= omegaPowBase;
            }

            return spectrum;
        }
        public static Complex[] DecimationInFrequency(Complex[] frame, bool direct)
        {
            if (frame.Length == 1) return frame;
            var halfSampleSize = frame.Length >> 1; // frame.Length/2
            var fullSampleSize = frame.Length;

            var arg = direct ? -DoublePi / fullSampleSize : DoublePi / fullSampleSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[fullSampleSize];

            for (var j = 0; j < halfSampleSize; j++)
            {
                spectrum[j] = frame[j] + frame[j + halfSampleSize];
                spectrum[j + halfSampleSize] = omega * (frame[j] - frame[j + halfSampleSize]);
                omega *= omegaPowBase;
            }

            var yTop = new Complex[halfSampleSize];
            var yBottom = new Complex[halfSampleSize];
            for (var i = 0; i < halfSampleSize; i++)
            {
                yTop[i] = spectrum[i];
                yBottom[i] = spectrum[i + halfSampleSize];
            }
            yTop = DecimationInFrequency(yTop, direct);
            yBottom = DecimationInFrequency(yBottom, direct);
            for (var i = 0; i < halfSampleSize; i++)
            {
                var j = i << 1; // i = 2*j;
                spectrum[j] = yTop[i];
                spectrum[j + 1] = yBottom[i];
            }

            return spectrum;
        }
    }
}
