   M S B A M L   `   `   `  ����  
BikeRental    BikeRental.BookingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��500��5   	   $	��500��6     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6   .��5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5!      �� 
�������$��Selected Bike:��6'   $��10q�6@   �� 5"      
�������$��1��6N   $��10q�6^   ��6'   �� *SelectedBike.Model+6^   �� 5$      
�������$��Rental Start Date:��6'   $��1��6D   $��10q�6Q   (  "System.Windows.Controls.DatePicker  5%      $��1��6C   $��1��6S   $��10q�6`   
���   �
�������   SelectedDate 6   �� *RentalStartDate+6   �� 5'      
�������$��Rental End Date:��6'   $��2��6B   $��10q�6O     5(      $��1��6@   $��2��6P   $��10q�6]   
���   �
������� 6   �� *RentalEndDate+6|   �� 5*      $
��Book��6   $��3��6D   $��2��6Q   $��10q�6e      MaterialDesignRaisedButton#��[  6q   ��6$   �� *BookCommand+6q   5+      5,      5-      