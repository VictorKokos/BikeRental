   M S B A M L   `   `   `  ����  
BikeRental     BikeRental.View.SignInView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��400��5   	   $	��250��6     � 	Resources  5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6   .��5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��1��6   $��20q�6&   .+�5      �� 
�������$��Login:��6+   �� 5       %  !MaterialDesignFloatingHintTextBox#��[  6A   
���   �
���������6   �� *UserAccount.UserLogin+6�   �� 5      
�������$��	Password:��6+   G� 5      -   5         G�Name$ passwordBox��5      
���   �
�������6F   �� 5      -   5        $��10q�5      $��Sign In��6|     MaterialDesignRaisedButton#��[ 6�   ��6%   �� *SignInCommand+��6G   ��  �� ElementName$ passwordBox��6�   �� 5!       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5"      �� $��Don't have an account? ��6    
�������6?   �� 5#      -   5        $��Sign Up��5#        MaterialDesignFlatButton#��[ 6J   
�������
���   �6�   5%      5&      5'      5(      5)      