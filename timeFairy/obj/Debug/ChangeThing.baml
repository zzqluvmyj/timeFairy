   M S B A M L   `   `   `  ����D  @timeFairy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:timeFairy	timeFairy  5   	       timeFairy.ChangeThing   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:timeFairy     5   	   X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  修改��5	   	   $	��380��6   $	��300��6!   ��5
      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFCCFBC4��6    � Offset$ 0Q�6-   � 5      $ 	#FFFFF2A1��6   $ 1Q�6-   5      .��5      �� $��10q�6   $	��250��6   ���	#FFA9F0C9 � 	Resources 5   
    �� 
TargetType �� Property �� Value	 �� 
TargetType��%  '��       '�� �    �� 5      " ��6   .�5      ��  � ��$ 2q�6+   �� 5       � |� .  6.   �� 5       � �� 5      �� 5      "	 ��6*   .R�5      ]� ��.  .+�5   "   �� $��Header��63   $
��Left=�6J   |�.  $��Center=�5   5   �� 5   "   $��Content��63   $��5,0,0,0q�6K   $��Right=�5   #   $��Center=�6:   5      5      5       5!      �� 5"      " ��6   .�5#      ��  � ��$	 100��6*   �� 5$       � ��$ 10,15,15,15q�6+   5&      5'      .+�5)   
   �� $��名称��6!   .��5*      �� -   5        
 ��Name$

 name��5*      $	��150��6$   ��60   �� *Name+ �� Mode$ TwoWay=�5+      �� 5,   
   $��	优先级��6!   .��5-      �� -   5        $
 priority��5-      $	��150��6(   ��64   �� *
Priority+$ TwoWay=� �� StringFormat$ d��5.      �� 5/   
   $��种类��6"   .��50      �� -   5        $

 kind��50   "   $	��150��6   ��60   �� *Kind+$ TwoWay=�$ d��51      �� 52   
   .��6   开始时间6   &   Xceed.Wpf.Toolkit.DateTimePicker  53   
   -   5          Name$ 	starttime��53      $��50.182��61   $
��10,0q�6A   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6O   �� *	StartTime+$ TwoWay=��� 55   
   .��6   结束时间6     56   
   -   5        $ endtime��56      $��50.182��6/   $
��10,0q�6?    6M   �� *	EndTime+$ TwoWay=��� 58   
   $��备注��6!   .��59      �� -   5        $	
 etc��59   "   $	��150��6   ��60   �� *Etc+$ TwoWay=�$ d��5:      �� 5;   
    �� Orientation$ 
Horizontal=�6   .+�5<      �� -   5         �� 	IsDefault . $��提交��5<   ;   �� 5=      -   5         �� IsCancel . $��返回��5=   :   5>      5?      5@      