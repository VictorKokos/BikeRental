   M S B A M L   `   `   `  ����  
BikeRental    BikeRental.BikeReviewView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5      �� $	��100��62   $	��100��6>   ��6   �� *
Bike.Image+6>   �� 5      $��24(�64   $��Center=�6B   $��10,0,0,0q�6]   ��6   �� *
Bike.Model+6]   5      �� 5!   
   $��1��62   ��6   �� *	Reviews+��5"      �� 5#      .R�5$      �� .+�5%      �� $
��Bold"�6B   ��6$   �� *ReviewHeader+6B   �� 5&      ��6$   �� *
ReviewText+�� 5'      $
��Bold"�6;   ��6$   �� *Score+6;   �� 5(      ��6$   �� *
AnswerText+5)      5*      5,      �� 5.   
   $ Vertical=�6   $��2��6,   .+�5/      �� $��30��6>   $��0,0,0,10q�6J   ��6   �� *NewReview.ReviewHeader+6J   �� 50      $	��100��6<   ��6   �� *NewReview.ReviewText+6<   �� 51       �� SelectedValuePath$ Content��6A   $��	0,10,0,10q�6]    �� SelectedValue 6   �� *NewReview.Score+.@�52      �� $��1��6   �� 53      $��2��6   �� 54      $��3��6   �� 55      $��4��6   �� 56      $��5��6   57      �� 58      $��Отправить��6      MaterialDesignRaisedButton#��[  6Q   ��6)   �� *SubmitReviewCommand+6Q   59      5:      5;      