   M S B A M L   `   `   `  ���� @  <MyPro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyProMyPro  'clr-namespace:MyPro.view
MyPro.view      MyPro.ChatClient   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:MyPro     )viewclr-namespace:MyPro.view       � Title$  
ChatClient��$	��470��$	��810�� � DataContext   MyPro.view.MainViewModel  .���  � ColumnDefinitions �� $	��200 �.+�]� .+��� -   $��UserN��$��25��$	��Top=����� *
Username+�� $��25��
����ح�$	��Top=�$��connect������ *ConnectToServerCommand+�� 
���������� *Users+���� .R��� ���� *
UserName+�� $��200,0,-600,0q�.+��� $	��380������ *
Messages+�� .+���  �� Orientation$ 
Horizontal=�.+��� $��55��$	��545��$��Center=����� *	Message+ �� UpdateSourceTrigger$ PropertyChanged=��� $��55��$��发送��
����ح����� *SendMessageCommand+