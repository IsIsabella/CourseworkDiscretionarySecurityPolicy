   M S B A M L   `   `   `  ����>  :DAC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DACDAC  5   	       DAC.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:DAC     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Icon$ icon.ico��5   
    � Title$ Библиотека��5
   
   $��521.732��6   $	��800��6.   $	��900��6:   $	��571��6I   
�������.��5      � .+�5   
   �� $��100,57,100,170q�6   .+�5      �� $��30(�6   $��Rockwell Extra Bold)�6"   .��6C   
Вход6I   �� 5      $��20(�6   $��Rockwell Extra Bold)�6"   .��6C   
Логин6J   �� 5      -   5         ��Name$ LoginTextBox��5      $��20(�6,   $	��400��6;   $
��Left=�6G   $��41��6b   �� 5      $��20(�6   $��Rockwell Extra Bold)�6"   .��6C   Пароль6K   G� 5      -   5         G�Name$ PasswordTextBox��5      $��20(�63   $	��400��6A   $
��Left=�6M    G� 	MaxLength$ 6��6h    G� PasswordChar$ X��6v   $��41��6�   5      �� 5   
   $��100,250,99.6,169.6q�6   .+�5      �� -   5        $��52��5      $	��125��6"   $��291,40,277.6,10q�6B   $��Center=�6[   $��Вход��6x   $��20(�6�   $��Rockwell Extra Bold)�6�   
��� ��� � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%^   '��       �� 5      " ��6   .�5      �� 	 �@��CornerRadius$
 5��69   5      5      5      5      �� 5   
   $��372,408,9.6,33.6q�6   .+�5      �� -   5        $��51��5      $	��345��6"   $��107,10,60,10q�6H   $��Center=�6^   $<��6Перезагрузка матрицы доступа��6{   $��20(�6�   $��Rockwell Extra Bold)�6�   
��� ��� 5      ��%^   '��       �� 5      " ��6   .�5       �� 	 �@��CornerRadius$
 5��65   5!      5"      5#      5$      5%      5&      