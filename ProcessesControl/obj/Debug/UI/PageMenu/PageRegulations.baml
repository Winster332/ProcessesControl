   M S B A M L   `   `   `  ����K  GProcessesControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProcessesControl.UI.PageMenuProcessesControl.UI.PageMenu  5      2    ,ProcessesControl.UI.PageMenu.PageRegulations   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:ProcessesControl.UI.PageMenu     5        � 	Resources  5	         MoveButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%.  &	        �� 5
      " ��6"   .�5      ��  � �� �#CCCCCC6"   �� 5       � �� �#6666666"   �� 5       � ��$ 20(�6    �� 5       � �� 5      �� 5      " ��6   .R�5      � #��z��6   .+�5   	   �� $
��Left=�5   	   $��Center=�5   	   $��10, 0, 0, 0q�5   	   5   	    5      P� 5   	    �@J�IsMouseOver . . �5   
   ��  � �� �#CCCCCC6'   5   
   P� 5   	    � �� . . �5   
   ��  � �� �#AAAAAA6'   5   
   5      5!      5"      5#      .��5$      � ���#E0E0E0$��
5, 0, 0, 0q�6    � RowDefinitions 5%      �� 5&      $��35 �6   �� 5'      $��* �6   �� 5(      $��7 �6   	 � ColumnDefinitions	 5*      .+�5-      �� $��0��6   $��0��6   $��Правила��6+   ���#707070$��25(�6O   $��Center=�6]   $��10, 0, 0, 0q�6x   �� 5.      
 �� Orientation$
 
Horizontal=�6   $��Right=�6(   .+�5/      �� -   5        $��80��5/      $��30��6     MetroButtonStyle#��[ 6#   $��Добавить��6M   
 � Tag$	 ADD��6`   6j   �� 50      -   5        $��80��50      $��30��6   #��[ 6#   $��Очистить��6M   $ CLEAR��6`   $��10, 0q�6�   51      �� 52        AppleStyleScrollBarStyle#��[ 6   $��0��6F   $��1��6V   $��0, 0, -10, 0q�6c   .��53      �� -   5        $��
stackPanel��53      $
 Vertical=�6"   ���#BBBBBB54      55      56      57      