   M S B A M L   `   `   `  ����@  <Etlap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EtlapEtlap  5   	       Etlap.FoodForm   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Etlap     5   	     � Title$  FoodForm��5   	   $	��450��6   $	��800��6'   .��5	      �  � RowDefinitions 5
      �� 5      $��30 �6   �� 5      $��90 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5       � ColumnDefinitions 5      �� 5      $	��150 �6   �� 5      .+�5      �� -   5         ��Name$ boxName��5   )   $��0��6   $��1��6   $
��Left=�6:   $��Center=�6U    �� TextWrapping$
 Wrap=�6p   $	��150��6�   �� 5      -   5        $ boxDesc��5   )   $��1��6   $��1��6   $
��Left=�6:   $��Center=�6U   $
 Wrap=�6p    �� AcceptsReturn$
 True��6�   " �� VerticalScrollBarVisibility$ Visible=�6�   $	��150��6�   $
��auto��6�   �� 5      -   5        $ boxPrice��5   )   $��2��6   $��1��6   $
��Left=�6;   $��Center=�6V   $
 Wrap=�6q   $	��150��6�   �� 5      -   5         ��Name$ 	BoxCourse��5   *   $��3��6   $��1��6   $
��Left=�6=   $��Center=�6X   $	��150��6s   �� 5      $��0��6
   $��Name:��6   $��Right=�6'   $��Center=�6C   �� 5      $��1��6
   $��Description:��6   $��Right=�6.   $��Center=�6J   �� 5      $��2��6
   $��Price:��6   $��Right=�6(   $��Center=�6D   �� 5      $��3��6
   $��Course:��6   $��Right=�6)   $��Center=�6E   �� 5       -   5         ��Name$ butnAdd��5    b   $��4��6   $��0��6   $��2��6(   $	��300��6<   $��20��6H   $	��Add��6T   $
��Left=�6s   $	��Top=�6�   6�   5"      5#      