   M S B A M L   `   `   `  ����D  @timeFairy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:timeFairy	timeFairy  5   	       timeFairy.AddThing   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:timeFairy     5   	   X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  	新事件��5	   	   $	��380��6   $	��300��6"   ��5
      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFCCFBC4��6    � Offset$ 0Q�6-   � 5      $ 	#FFFFF2A1��6   $ 1Q�6-   5      .��5      �� -   5         ��Name$ stack��5   )   $��10q�6   $	��250��6   ���	#FFA9F0C9 � 	Resources 5   
    �� 
TargetType �� Property	 �� Value
 �� 
TargetType��%  '��       '�� �    �� 5      " ��6   .�5      ��  � ��$	 2q�6+   �� 5       � |�	 .  6.   �� 5       � ��	 5      �� 5      "
 ��6*   .R�5      ]� ��.  .+�5   "   �� $��Header��63   $
��Left=�6J   |�.  $��Center=�5   5   �� 5   "   $��Content��63   $��5,0,0,0q�6K   $��Right=�5   #   $��Center=�6:   5      5      5       5!      �� 5"      " ��6   .�5#      ��  � ��$		 100��6*   �� 5$       � ��$	 10,15,15,15q�6+   5&      5'      .+�5)   
   �� $��名称��6!   .��5*      �� -   5         ��Name$
 name��5*      $	��150��6$   ��60   �� *Name+ �� Mode$ TwoWay=�5+      �� 5,   
   $��	优先级��6!   .��5-      �� -   5        $ priority��5-      $	��150��6(   ��64   �� *
Priority+$ TwoWay=� �� StringFormat$ d��5.      �� 5/   
   $��种类��6!   .��50      �� $	��150��6   ��6"   �� *Kind+$ TwoWay=�$ d��51      �� 52   
   .��6   开始时间6   &   Xceed.Wpf.Toolkit.DateTimePicker  53   
   $��50.182��6   $
��10,0q�6.   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6<   �� *	StartTime+$ TwoWay=��� 55   
   $��开始时间��6!   .��56      �� $	��150��6   ��6"   �� *	StartTime+$ TwoWay=�57      �� 58   
   .��6   结束时间6     59   
   $��50.182��6   $
��10,0q�6.    6<   �� *	EndTime+$ TwoWay=��� 5:   
   $��结束时间��6!   .��5;      �� $	��150��6   ��6"   �� *	EndTime+$ TwoWay=�$ d��5<      �� 5>   
   $��备注��6!   .��5?      �� $	��150��6   ��6"   �� *Etc+$ TwoWay=�$ d��5@      �� 5A   
    �� Orientation$ 
Horizontal=�6   .+�5B      �� -   5         �� 	IsDefault . $��提交��5B   ;   �� 5C      -   5         �� IsCancel . $��返回��5C   :   5D      5E      5F      