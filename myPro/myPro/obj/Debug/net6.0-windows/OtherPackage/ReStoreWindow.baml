   M S B A M L   `   `   `  ����@  <MyPro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyProMyPro  5   	       MyPro.ReStoreWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MyPro     5   	     � Title$  ReStoreWindow��5   	   $	��350��6   $	��600��6,   .��5	      � .+�5
   
   �� -   5        $��添加图片��5
      $
��Left=�6    $��136,253,0,0q�6;   $	��Top=�6P   $��75��6h   
����ح�6�   �� 5   
   $��编号:��6   $
��Left=�6   $��
314,98,0,0q�69   $	��Top=�6M    J� RenderTransformOrigin$ -0.342,-0.116&�6e   �� 5   
   $��名字:��6   $
��Left=�6   $��314,134,0,0q�6:   $	��Top=�6O   �� 5   
   $��货架数量:��6   $
��Left=�6!   $��290,213,0,0q�6<   $	��Top=�6Q   �� 5   
   -   5        $��GNumber��5      $
��Left=�6!   $��26��6<   $��
381,98,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��140��6�   $��Center=�6�   .��6�    � 	Resources 5         GN j� TileMode �� Opacity j� Stretch j� 
AlignmentX !� Visual��%�   &	        !� 5      $
 None=�6)   $	 0.3Q�69   $
 None=�6G   $
 Left=�6V    5      �� 5      $	��GID��6$   $��Italic$�6/   $$��输入货物编号进行修改��6B   6V   5      5      .��6!   ��5      �� 5      	 �� 
TargetType"	 ��6   
 �� Triggers
 5      P� 5       P� Property � �� P� Value 62   Z� . �5      ��  �� Property � �� �� Value# [  6;   5      P� 5       � ��$  ��62   . �5      ��  � ��# [  6;   5      5       .��5!      5"      �� 5#   
   -   5        $��	GoodsName��5#      $
��Left=�6#   $��23��6>   $��381,138,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6|   $	��140��6�   �� 5$   
   -   5        $��
GoodsCount��5$      $
��Left=�6$   $��23��6?   $��381,213,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6}   $	��140��6�   �� 5%   
   -   5        $��GoodsPic��5%      $
��Left=�6!   $	��128��6<   $��
108,98,0,0q�6I   $	��Top=�6]   $	��130��6u   �� 5&   
   -   5        $��添加��5&      $
��Left=�6   $��279,253,0,0q�69   $	��Top=�6N   $��75��6f   
����ح�6�   �� 5'   
   -   5        $��CB��5'      $��修改��6   $
��Left=�6(   $��426,253,0,0q�6C   $	��Top=�6X   $��75��6p   
����ح�6�   �� 5(   
   $��仓库数量:��6   $
��Left=�6!   $��290,175,0,0q�6<   $	��Top=�6Q   �� 5)   
   -   5         ��Name$ StorageGoodsCount��5)      $
��Left=�6-   $��23��6H   $��381,175,0,0q�6T   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��140��6�   5+      5,      