   M S B A M L   `   `   `  ����  NIST_OOP    NIST_OOP.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  Window��5   	    � Title$ 
MainWindow��5   	   $	��500��6   $	��625��6)   $	��400��65   $	��625��6E    � WindowStyle$ ThreeDBorderWindow=�6o   .��5      �� $��Visible=�6   $��Visible=�69   .��5   
   � -   5        $��controls��5       � ShowGridLines .   � ColumnDefinitions 5      �� 5	      $
��0.6* �6#   �� 5
      $
��0.2* �6#   �� 5      $
��0.2* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5       �� -   5         ��Name$ Label1��5       $��Frequency(Monobit) test��6$   $
��Left=�6F   $��10q�6a   $��1��6m   $��Center=�6z   $��Showcard Gothic)�6�   �� 5!      -   5        $ Label2��5!      $#��Frequency test within a block��6$   $
��Left=�6L   $��10q�6g   $��2��6s   $��Center=�6�   $��Showcard Gothic)�6�   �� 5"      -   5         ��Name$ TextBox0��5"      $��10q�6(    �� TextWrapping$ WrapWithOverflow=�64   $��3��6T   $	��150��6h   "	 �� VerticalScrollBarVisibility$	 Visible=�6u   
 �� AcceptsReturn
 . $	��Top=�6�   $	��555��6�   �� 5#      -   5        $ Label3��5#      $��	Runs test��6$   $
��Left=�68   $��10q�6S   $��3��6_   $��Center=�6l   $��Showcard Gothic)�6�   �� 5$      -   5        $ Label4��5$      $/��)Test for the longest run of ones in block��6$   $
��Left=�6X   $��10q�6s   $��4��6   $��Center=�6�   $��Showcard Gothic)�6�   �� 5%      -   5        $ Label5��5%      $��Matrix rang test��6$   $
��Left=�6?   $��10q�6Z   $��5��6f   $��Center=�6s   $��Showcard Gothic)�6�   �� 5&      -	   5        $ Label6��5&      $��DFT test��6$   $
��Left=�67   $��10q�6R   $��6��6^   $��Center=�6k   $��Showcard Gothic)�6�   �� 5'      -
   5        $ Label7��5'      $-��'Non-overlapping Template Matching Test ��6$   $
��Left=�6V   $��10q�6q   $��7��6}   $��Center=�6�   $��Showcard Gothic)�6�   �� 5(      -   5        $ Label8��5(      $)��#Overlapping Template Matching Test ��6$   $
��Left=�6R   $��10q�6m   $��8��6y   $��Center=�6�   $��Showcard Gothic)�6�   �� 5)      -   5        $ Label9��5)      $&�� Mauer's universal statistic test��6$   $
��Left=�6O   $��10q�6j   $��9��6v   $��Center=�6�   $��Showcard Gothic)�6�   �� 5*      -   5        $ Label10��5*      $��Serial test��6%   $
��Left=�6;   $��10q�6V   $��10��6b   $��Center=�6p   $��Showcard Gothic)�6�   �� 5+      -   5        $ Label11��5+      $��Approximate entropy test��6%   $
��Left=�6H   $��10q�6c   $��11��6o   $��Center=�6}   $��Showcard Gothic)�6�   �� 5,      -   5        $ Label12��5,      $��Cummulative sums test��6%   $
��Left=�6E   $��10q�6`   $��12��6l   $��Center=�6z   $��Showcard Gothic)�6�   �� 5-      -   5        $ Label13��5-      $��Random excursion test��6%   $
��Left=�6E   $��10q�6`   $��13��6l   $��Center=�6z   $��Showcard Gothic)�6�   �� 5.      -   5        $ Label14��5.      $#��Random excursion variant test��6%   $
��Left=�6M   $��10q�6h   $��14��6t   $��Center=�6�   $��Showcard Gothic)�6�   �� 5/      -   5        $ Label15��5/      $��Linear complexity test��6%   $
��Left=�6F   $��10q�6a   $��15��6m   $��Center=�6{   $��Showcard Gothic)�6�   �� 53      -   5         ��Name$ 	CheckBox1��53      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��1��6t   $��Center=�6�   {�.  6�   �� 54      -   5        $ 	CheckBox2��54      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��2��6t   $��Center=�6�   {�.  6�   �� 55      -   5        $ 	CheckBox3��55      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��3��6t   $��Center=�6�   {�.  6�   �� 56      -   5        $ 	CheckBox4��56      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��4��6t   $��Center=�6�   {�.  6�   �� 57      -   5        $ 	CheckBox5��57      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��5��6t   $��Center=�6�   {�.  6�   �� 58      -   5        $ 	CheckBox6��58      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��6��6t   $��Center=�6�   {�.  6�   �� 59      -   5        $ 	CheckBox7��59      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��7��6t   $��Center=�6�   {�.  6�   �� 5:      -   5        $ 	CheckBox8��5:      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��8��6t   $��Center=�6�   {�.  6�   �� 5;      -   5        $ 	CheckBox9��5;      $��Passed��6*   $��1��6;   $��Center=�6K   $��10q�6h   $��9��6t   $��Center=�6�   {�.  6�   �� 5<      -   5        $ 
CheckBox10��5<      $��Passed��6+   $��1��6<   $��Center=�6L   $��10q�6i   $��10��6u   $��Center=�6�   {�.  6�   �� 5=      -   5        $ 
CheckBox11��5=      $��Passed��6+   $��1��6<   $��Center=�6L   $��10q�6i   $��11��6u   $��Center=�6�   {�.  6�   �� 5>      -   5        $ 
CheckBox12��5>      $��Passed��6+   $��1��6<   $��Center=�6L   $��10q�6i   $��12��6u   $��Center=�6�   {�.  6�   �� 5?      -   5        $ 
CheckBox13��5?      $��Passed��6+   $��1��6<   $��Center=�6L   $��10q�6i   $��13��6u   $��Center=�6�   {�.  6�   �� 5@      -    5        $ 
CheckBox14��5@      $��Passed��6+   $��1��6<   $��Center=�6L   $��10q�6i   $��14��6u   $��Center=�6�   {�.  6�   �� 5A      -!   5        $ 
CheckBox15��5A      $��Passed��6+   $��1��6<   $��Center=�6L   $��10q�6i   $��15��6u   $��Center=�6�   {�.  6�   �� 5C      -"   5        $ TextBox1��5C      $��2��6(   $��10q�68   $��1��6D   $
 Wrap=�6Q   �� 5D      -#   5        $ TextBox2��5D      $��2��6(   $��10q�68   $��2��6D   $
 Wrap=�6Q   �� 5E      -$   5        $ TextBox3��5E      $��2��6(   $��10q�68   $��3��6D   $
 Wrap=�6Q   �� 5F      -%   5        $ TextBox4��5F      $��2��6(   $��10q�68   $��4��6D   $
 Wrap=�6Q   �� 5G      -&   5        $ TextBox5��5G      $��2��6(   $��10q�68   $��5��6D   $
 Wrap=�6Q   �� 5H      -'   5        $ TextBox6��5H      $��2��6(   $��10q�68   $��6��6D   $
 Wrap=�6Q   �� 5I      -(   5        $ TextBox7��5I      $��2��6(   $��10q�68   $��7��6D   $
 Wrap=�6Q   �� 5J      -)   5        $ TextBox8��5J      $��2��6(   $��10q�68   $��8��6D   $
 Wrap=�6Q   �� 5K      -*   5        $ TextBox9��5K      $��2��6(   $��10q�68   $��9��6D   $
 Wrap=�6Q   �� 5L      -+   5        $ 	TextBox10��5L      $��2��6)   $��10q�69   $��10��6E   $
 Wrap=�6S   �� 5M      -,   5        $ 	TextBox11��5M      $��2��6)   $��10q�69   $��11��6E   $
 Wrap=�6S   �� 5N      --   5        $ 	TextBox12��5N      $��2��6)   $��10q�69   $��12��6E   $
 Wrap=�6S   �� 5O      -.   5        $ 	TextBox13��5O      $��2��6)   $��10q�69   $��13��6E   $
 Wrap=�6S   �� 5P      -/   5        $ 	TextBox14��5P      $��2��6)   $��10q�69   $��14��6E   $
 Wrap=�6S   �� 5Q      -0   5        $ 	TextBox15��5Q      $��2��6)   $��10q�69   $��15��6E   $
 Wrap=�6S   �� 5R      -1   5         ��Name$ Perform��5R      $��Perform��6&   $��Center=�68   $��10q�6U   $��16��6a   $��Center=�6o   $��75��6�   $��2��6�   6�   5U      5V      5W      