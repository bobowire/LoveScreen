   M S B A M L   `   `   `  ����N  JLoveScreen.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LoveScreen.ControlsLoveScreen.Controls  5      K*clr-namespace:LoveScreen.Controls.ConvertsLoveScreen.Controls.Converts  5      $    LoveScreen.Controls.SizePicker   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:LoveScreen.Controls     5      >convert*clr-namespace:LoveScreen.Controls.Converts     5        � 	Resources  5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value6   0LoveScreen.Controls.Converts.IntListIndexConvert   IntListIndexConvert��%�   '��       &	  �     �� 5   
   " ��6    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��$ 1��68   6D   �� 5       � ��
 �����6>   5      5        5   
   6D   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��30 �6   6-   �� 5      $��30 �6   6-   �� 5      $��30 �6   6-    � RowDefinitions 5   
   �� 5      $��30 �6   6*   .+�5   
   �� $��4q�6   
�������$��1��6-   ��6A   �� 	 �� Path$	 SelectedSize�
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType$   LoveScreen.Controls.SizePicker"   �� 	Converter# [   �� ConverterParameter$ 2,5,8��6  A� 5!   
   $��Center=�6   $��Center=�6-   $��0��6J   $��2��6Z   
���   ���6d   �� $	 Width�
 ��  �� Mode$
 Self=�6�   A� 5"   
   $��Center=�6   $��Center=�6-   $��1��6J   $��5��6Z   
���   ���6d   �� $	 Width�
 �� $
 Self=�6�   A� 5#   
   $��Center=�6   $��Center=�6-   $��2��6J   $��8��6Z   
���   ���6d   �� $	 Width�
 �� $
 Self=�6�   �� 5$   
   -   5        $��4q�5$      
 � Tag$ 2��6=   $��0��6E   
������ 6j   �� 5%   
   -   5        $��4q�5%      $ 5��6=   $��1��6E   
������ 6j   �� 5&   
   -   5        $��4q�5&      $ 8��6=   $��2��6E   
������ 6j   5'      5(      