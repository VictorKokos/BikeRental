   M S B A M L   `   `   `  ����  
BikeRental    BikeRental.PaymentView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��500��5   	   $	��500��6     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6   .��5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5"      �� 
�������$��Card Number:��6'   $��10q�6>   �� 5#      $��1��62   $��10q�6B    %  !MaterialDesignFloatingHintTextBox#��[  6N   
���   �
���������6   �� *
CardNumber+6�   �� 5%      
�������$��Card Holder Name:��6'   $��1��6C   $��10q�6P   �� 5&      $��1��66   $��1��6F   $��10q�6S   #��[  6_   
���   �
���������6   �� *CardHolderName+6�   �� 5(      
�������$��Expiry Date (MM/YY):��6'   $��2��6F   $��10q�6S   �� 5)      $��1��62   $��2��6B   $��10q�6O   #��[  6[   
���   �
���������6   �� *
ExpiryDate+6�   �� 5+      
�������$
��CVV:��6'   $��3��66   $��10q�6C   �� 5,      $��1��6+   $��3��6;   $��10q�6H   #��[  6T   
���   �
���������6   �� *CVV+6�   �� 5.      
�������$��Total Cost:��6'   $��4��6=   $��10q�6J   �� 5/      
�������$��1��6E   $��4��6U   $��10q�6b   ��6'   �� *	TotalCost+6b   �� 51      $	��Pay��6   $��5��6B   $��2��6O   $��10q�6c     MaterialDesignRaisedButton#��[ 6o   ��6#   �� *
PayCommand+6o   52      53      54      