   M S B A M L   `   `   `  ����K  GProcessesControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProcessesControl.UIProcessesControl.UI  5      %    ProcessesControl.UI.ListBoxMenu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ProcessesControl.UI     5        � 	Resources  5	         MoveButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%.  &	        �� 5
      " ��6"   .�5      ��  � �� �#E0E0E06"   �� 5       � �� �#6666666"   �� 5       � ��$ 20(�6    �� 5       � �� 5      �� 5      " ��6   .R�5      � #��z��6   .+�5   	   �� $
��Left=�5   	   $��Center=�5   	   $��10, 0, 0, 0q�5   	   5   	    5      P� 5   	    �@J�IsMouseOver . . �5   
   ��  � �� �#CCCCCC6'   5   
   P� 5   	    � �� . . �5   
   ��  � �� �#AAAAAA6'   5   
   5      5!      5"      5#      .��5$      � ���#E0E0E0 � RowDefinitions 5%      �� 5&      $��50 �6   �� 5'      $��* �6   �� 5(      $��7 �6   	 � ColumnDefinitions	 5*      .+�5-      �� $��0��6   $��0��6   $��Меню��6+   ���#707070$��35(�6L   $��Center=�6Z   $��10, 0, 0, 0q�6u   �� 5.        AppleStyleScrollBarStyle#��[ 6   $��0��6F   $��1��6V   $��0, 0, -10, 0q�6c   .��5/      �� -   5        $��
stackPanel��5/      
 �� Orientation$
 Vertical=�6"   ���#E0E0E0.+�50      �� -   5        $��45��50      #��[  6   $��ПРОЦЕССЫ��6B   
 � Tag$ 	processes��6k   �� 51      -   5        $��45��51      #��[  6   $��ПРАВИЛА��6B   $ 
regulation��6j   �� 52      -   5        $��45��52      #��[  6   $��ЛОГИ��6B   $
 logs��6h   �� 53      -   5        $��45��53      #��[  6   $��АВТОЗАПУСК��6B   $ autorun��6l   �� 54      -   5        $��45��54      #��[  6   $��НАСТРОЙКИ��6B   $ settings��6k   �� 55      -   5        $��45��55      #��[  6   $��
ВЫХОД��6B   $
 exit��6h   56      57      58      59      