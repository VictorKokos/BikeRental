   M S B A M L   `   `   `  ����E  ABikeRental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BikeRental.ViewBikeRental.View  5      $    BikeRental.View.ReviewItemView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:BikeRental.View     5      .��5	      �� 
���   �$��1q�6!     �� CornerRadius$  2��65    �� Padding$ 10q�6F   ._�5
   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $��20(�6%   $
��Bold"�63   ��6E   ��  �� Path$ ReviewHeader��� 5      $��1��6   $��0,10,0,0q�6%   ��67   �� $ ClientId� �� StringFormat$" ID велосипеда: {0}���� 5      $��2��6   $��0,10,0,0q�6%   $
��Wrap=�6s   ��67   �� $ 
ReviewText�$ Отзыв: {0}��6s   �� 5      $��3��6   $��0,10,0,0q�6%   ��67   �� $ Score�$ Оценка: {0}���� 5      $��4��6   $��0,10,0,0q�6%   $
��Wrap=�6s   ��67   �� $ 
AnswerText�$ Ответ: {0}��6s   5      5      5      