   M S B A M L   `   `   `  ����E  ABikeRental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BikeRental
BikeRental  5   	   1clr-namespace:BikeRental.ViewBikeRental.View  60       BikeRental.ItemCatalog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:BikeRental     5   	   4
BikeRentalclr-namespace:BikeRental.View     60     � Title$  
MainWindow��5   	    � WindowState$ 	Maximized=�6    � 	Resources 5	      ,   &BikeRental.View.IsBookingTypeConverter   IsBookingTypeConverter  IsNullTypeConverter/   )BikeRental.View.RoleToVisibilityConverter  RoleToVisibilityConverter6   0BikeRental.View.RoleToVisibilityInverseConverter $  RoleToVisibilityInverseConverter*   $BikeRental.View.ItemTemplateSelector  itemTemplateSelector   BikeTemplate �� DataType   BikeRental.Bike"   BikeRental.View.BikeItemView   ReviewTemplate   BikeRental.Review$   BikeRental.View.ReviewItemView   BookingTemplate	   BikeRental.Booking%
   BikeRental.View.BookingItemView   PaymentTemplate   BikeRental.Payment%   BikeRental.View.PaymentItemView  ButtonStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius��%�  &	        &	      &	 &     &	 9     &	 L     &	 �      5   
   6,     5   
   6,     5   
   6/     5   
   66     5   
    5      �� 5      "  6#   (��       *, +).R�5        5       5      �� 5      "  6#   (��       *, +).R�5        5       5      �� 5      " 	 6   (��       *,	 +).R�5       
  5!       5#      �� 5$      "  6   (��       *, +).R�5%        5&      5(      �� 5-   
   " ��6$   .�5.      �� 	 � ��

 ��ح�6+   �� 5/      	 � ��$

 Auto��6&   �� 50      	 � ��$

 Auto��6'   �� 51      	 � ��$
 10q�6'   �� 52      	 � ��$
 10q�6(   �� 53      	 � ��$
 Segoe UI)�6+   �� 54      	 � ��$
 20(�6)   �� 55      	 � ��
 56      �� 57      " ��6&   .R�58      �� #��z��6!   
���   �$��1q�6_   $ 4��6s   ._�59      �� $��Center=�6/   $��Center=�6L   5:      5;      5=      5>      5@      .��5B   
   � ��5C      �� 5D       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5E      �  � Color$ 	LightBlue��6#    � Offset$	 0.0Q�65   � 5F      $ SkyBlue��6#   $	 1.0Q�63   5G       � RowDefinitions 5I      �� 5J      $
��Auto �6    �� 5K      $��* �6    �� 5L      $
��Auto �6     � ColumnDefinitions 5N      �� 5O      $��* �6#   �� 5P      $	��400 �6#   .+�5R      �� $��0��6   $��2��6&    �� Orientation$ 
Horizontal=�6:   $��Center=�6S   .+�5S      �� -   5        $��Bikes��5T      #��[ 6G   y�5S      �� "   BikeRental.View.SessionState   CurrentUser �� Source# Z  �� Path$
 Role� �� 	Converter# [ 5T   G   �� 5U      -   5        $��Bookings��5V      #��[ 6M   y�5U      �� # Z $
 Role�# [ 5V   M   �� 5W      -   5        $��Payments��5X      #��[ 6P   y�5W      �� # Z $
 Role�# [ 5X   P   �� 5Y      -   5        $��Reviews��5Z      #��[ 6L   y�5Y      �� # Z $
 Role�# [ 5Z   L   �� 5[      -   5        $��
Выйти��5[      #��[ 6@   5]      �� 5^      $��1��6   $��0��6#   #��[ 5`   
   ��5^   3   �� *Items+ �� SelectedItem 5_   
   �� *SelectedItem+��5a      �� 5b      .R�5c      �  � Orientation$ 
Horizontal=�6    ��69   �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType ScrollContentPresenter5d      5f      �� 5g      $��2��6   $��2��6&   $ 
Horizontal=�6:   $��Center=�6S   .+�5h      �� $��Добавить��6   #��[ 6G   ��6(   �� *
AddCommand+y�5i   	   �� # Z $
 Role�# [ �� 5k      ��6   �� *RemoveCommand+��5l      �� *SelectedItem+y�6,   �� # Z $
 Role�# [ ��5m      �� 5n      " ��6    �� BasedOn# [ 60   .�5o      �� 	 � ��$
 Удалить��64   �� 5p      	 � y�$
 Visible=�67    �� Triggers 5q      �� 5r       �� Binding 6*   �� *SelectedItem+# [   �� Value True6~   .a�5s   "   �� 	 � ��$
 Отменить��6<   5t      5z      5|      �� 5      #��[ 6�   y�6   �� # Z $
 Role�# [ ��6�   �� *EditCommand+.��6�   Редактировать6�   �� 5�      $ ��Забронировать��5�      #��[ 6-   y�5�      �� # Z $
 Role�# [ ��5�   R   �� *BookCommand+��5�      �� �� 5�      $��Отзывы��5�      #��[ 6   y�5�      �� # Z $
 Role�# [ ��5�   B   �� *ReviewCommand+��5�      �� 5�      5�      5�      