   M S B A M L   `   `   `  ����@  <myPro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:myPromyPro  5   	       myPro.StoreHouseWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:myPro     5   	     � Title$  StoreHouseWindow��5   	   $	��450��6"   $	��700��6/    � 	Resources 5	         myPro.StoreGoods 	  Goods��%   &	          5
   
   6+   5      .��5      � .+�5   
   � -   5        $
��left��5      $
��Left=�6   $	��420��66   $	��Top=�6C   $	��180��6[   
������.+�5      �� -   5        $��userHeadpic��5      $
��Left=�6'   $	��100��6B   $��	42,23,0,0q�6O   $	��Top=�6b   $	��100��6z   �� 5      -   5        $��
userMassge��5      $��个人信息��6'   $
��Left=�66   $��	0,169,0,0q�6Q   $	��Top=�6d   $	��180��6|   $��43��6�   
������$��0q�6�   $��15(�6�   
�������6�   �� 5      -   5        $��仓库整理��5      $
��Left=�6$   $��	0,213,0,0q�6?   $	��Top=�6R   $	��180��6j    J� RenderTransformOrigin$ 0.5,0.5&�6v   $��43��6�   
������$��0q�6�   $��15(�6�   
�������5      �� 5      $��留言提示��6   $
��Left=�6$   $��	0,257,0,0q�6?   $	��Top=�6R   $	��180��6j   $��43��6v   
������$��0q�6�   $��15(�6�   
�������6�   �� 5      -   5        $��退出��5      $
��Left=�6"   $��	0,349,0,0q�6=   $	��Top=�6P   $	��180��6h   $��43��6t   
������$��0q�6�   $��15(�6�   
�������6�   �� 5      -   5        $��	User_Name��5      $�� ��6%   $
��Left=�60   $��
73,128,0,0q�6K   $	��Top=�6_   $ 0.275,-0.097&�6w   �� 5      -   5        $��刷新��5      $
��Left=�6"   $��	0,300,0,0q�6=   $	��Top=�6P   $	��180��6h   $��43��6t   
������$��0q�6�   $��15(�6�   
�������6�   5      � 5   
    � DataContext# [  6   .+�5      �� ���	#FFB2B2B2
�������$��180,0,-0.4,0q�6A   $��1q�6W   ._�5      � -   5         �Name$ contentGrid��5   �   $
��Left=�6   $	��420��62   $��0.2,-0.8,-1.2,-1.6q�6?   $	��Top=�6[   $	��513��6s   .+�5      �� -	   5         ��Name$ listbox��5      $��	-1,0,10,0q�6U   $	��Top=�6h   ��60   �� *
StoreGoods+��5      �� 5      .R�5   "   � $��10q�6'   $	��126��63   $	��135��6?    J� Effect 5   &   3  -System.Windows.Media.Effects.DropShadowEffect  5    *      ShadowDepth$ -4Q�6;      
BlurRadius$ 5Q�6L   	   Color$	 	LightGray��6[   
 � RowDefinitions
 5"   &   �� 5#   *   $
��auto �68   6H   �� 5$   *   $
��auto �68   6H   .+�5'   &   �� -
   5        $��Center=�5'   D   $	��Top=�6a   $	��107��6y   $	��107��6�   ��6-   �� *Img+6�   �� 5(   &   $��1��6F   $
��Wrap=�6S   $	��Top=�6g   $��Center=�6   $��28��6�   ��60   �� *Name+6�   5)   #   5*      ��5,      �� 5-       �� 
TargetType" ��6.   .R�5.   "   �� $��Disabled=�6/   $
��Auto=�6X   .��5/   &   �  � Orientation$ 
Horizontal=�60    K� IsItemsHost . ��. 6\   50   #   51      53      54      55      56      58      59      