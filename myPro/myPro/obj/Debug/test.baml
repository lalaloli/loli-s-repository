   M S B A M L   `   `   `  ����@  <myPro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:myPromyPro  5   	       
myPro.test   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:myPro     5   	     � Title$
  test��5   	   $	��550��6   $
��1000��6#   .��5
      � .+�5   
   �� ���	#FFB2B2B2
�������$��180,0,-0.4,0q�6=   $��1q�6S   ._�5      � -   5         �Name$ contentGrid��5   |   $
��Left=�6   $	��521��6.   $��0.2,-0.8,-0.4,-1.8q�6;   $	��Top=�6W   $	��813��6o   .+�5      �� -   5         ��Name$ listbox��5      $��	-1,0,10,0q�6L   $	��Top=�6_   ��6,   �� *Users+��5      �� 5      .R�5      � $��10q�6#   $	��126��6/   $	��135��6;    J� Effect 5   "   3  -System.Windows.Media.Effects.DropShadowEffect  5   &      ShadowDepth$ -4Q�67      
BlurRadius$ 5Q�6H      Color$ 	LightGray��6W    � RowDefinitions 5   "   �� 5   &   $
��auto �64   6D   �� 5   &   $
��auto �64   6D   .+�5   "   �� $��Center=�6?   $	��Top=�6\   $	��107��6t   $	��107��6�   ��6(   �� *Img+6�   �� 5   "   $��1��6B   $
��Wrap=�6O   $	��Top=�6c   $��Center=�6{   $��28��6�   ��6,   �� *Name+6�   5      5      ��5      �� 5        �� 
TargetType" ��6*   .R�5!      �� $��Disabled=�6+   $
��Auto=�6T   .��5"   "   � 	 � Orientation$	 
Horizontal=�6,   
 K� IsItemsHost
 . ��. 6X   5#      5$      5&      5'      5(      5)      5*      