   M S B A M L   `   `   `  ����H  DHomeWork48WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HomeWork48WPFHomeWork48WPF  5   	       HomeWork48WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HomeWork48WPF     5   	   -   5        $��myWindow��5   5     � Title$  
MainWindow��6	   $	��800��6   $	��800��6)   
����� � � 	Resources 5	       �� 
TargetType   
btTemplate ��Name �� CornerRadius �� Triggers P� Property P� Value �� Property	 �� Value
 �� 
TargetName :� RoutedEvent��%'  &	        �� 5
   
   " ��6   .R�5      �� $ buttonBorder��6   $ 25��6+   
�����_�$��2q�6U   $��45��5      $	��400��6$   $	��200��63   #��z��6B   $��10q�6l   ._�5      �� $��10q�6!   $��Center=�6-   $��Center=�6J   #��z��6e   5       5      P� 5       �@J�IsMouseOver . . �5      ��  � ��$
	 Bold"�64   �� 5      $
 buttonBorder��6    � ��
	 �����6M   �� 5      $
 buttonBorder��6    � ��
	 �����6N   5      P� 5       � �� . . �5      �� $
 buttonBorder��6    � ��	 �#f7a99e6M   �� 5      $
 buttonBorder��6    � ��
	 �  ��6N   5      P� 5       � {� . . �5      ��  � ��
	 �   �63   5      :� 5      $ Button.Click��6   5       5"      5#      .��5$      (� .��5%   
   ��  �� Orientation$ Vertical=�6   $	��800��6,   $	��800��6<   
����� �$	��441��6_   $	��513��6l   .+�5&      ��  �� Padding$ 10q�6    �� TextAlignment$ Center=�6%   $��50��6<   $��Arial)�6K   $��37(�6^   $	��600��6l   $	��200��6{   $��68��6�   $��
0,0,-0.2,0q�6�   �� 6�   $"�How do you like your coffee?��6�   6�   �� 5'      -   5        $
��btn1��5'      #��[  6!   $��Black��6H   ���#d5e0f26m   �� 5(      -   5        $
��btn2��5(      #��[  6!   $��	With milk��6I   ���#d5e0f26r   �� 5)      -   5        $
��btn3��5)      #��[  6!   $��Latte��6H   ���#d5e0f26o   �� 5*      -   5        $
��btn4��5*      $��
Cappuccino��6!   #��[  66   ���#d5e0f26r   �� 5+      -   5         ��Name$ 
stackPanel��5+      $��10q�6-   .+�5,      	� -   5        $��radio1��5,       	� 	GroupName$ Sugar��6,   $��
Sugar free��6>    d� 	IsChecked$ FalseY�6S   $��5q�6e   6p   	� 5-      -   5        $��radio2��5-      $ Sugar��6,   $��1 teaspoon of sugar��6>   $ FalseY�6\   $��5q�6n   6y   	� 5.      -	   5        $��radio3��5.      $ Sugar��6,   $��2 teaspoons of sugar��6>   $ FalseY�6]   $��5q�6o   6z   	� 5/      -
   5        $��radio4��5/      $ Sugar��6,   $��3 teaspoons of sugar��6>   $ FalseY�6]   $��5q�6o   6{   50      53      54      55      