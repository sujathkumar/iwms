   M S B A M L   `   `   `  ����,  (IWMS.Solutions.Client.CollectorDashboard1    +IWMS.Solutions.Client.Dashboard.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Q MWPFSmartLibraryLight35, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7wpfsl+http://schemas.softarcs.com/wpfsmartlibrary  5   	     � Title$  Login��5   	   $	��350��6   $	��525��6$    � WindowStartupLocation$ CenterScreen=�60    � WindowStyle$
 None=�6U    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $J D/WPFSmartLibraryLight35;component/ResourceDictionaries/CommonRD.xaml?�6%   �� 5      $ LoginDialog.xaml?�6%   %    5      .��5      � -   5         �Name$ 
LayoutRoot��5      ���	#FF16499A � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        	 ��Name$	 btnCollector��5      $��10q�6B   $
��Auto��6N   $
��Auto��6\   $��0��6i   $��0��6v   
�������.��5      �� $��yC:\Users\nairs6\Documents\Visual Studio 2013\Projects\IWMS.Solutions\IWMS.Solutions.Client.Dashboard\Images\collector.jpg��6   6�   5      �� 5   
   $��Collector's Dashboard��6   $
��Wrap=�61   
 �� TextAlignment$
 Center=�6E   $��16(�6\   
�������$��1��6}   $��0��6�   ���	#FF16499A6�   �� 5!   
   -   5        $	 btnRecycler��5!      |�.  $��10q�6R   $
��Auto��6^   $
��Auto��6l   $��0��6y   $��1��6�   
�������.��5"      �� $~��xC:\Users\nairs6\Documents\Visual Studio 2013\Projects\IWMS.Solutions\IWMS.Solutions.Client.Dashboard\Images\recycler.jpg��6   6�   5#      �� 5$   
   $��Recycler's Dashboard��6   $
��Wrap=�60   $
 Center=�6D   $��16(�6[   
�������$��1��6|   $��1��6�   ���	#FF16499A6�   �� 5&   
   -   5        $	 btnBBMP��5&      $��10q�68   $
��Auto��6D   $
��Auto��6R   $��0��6_   $��2��6l   
�������.��5'      �� $z��tC:\Users\nairs6\Documents\Visual Studio 2013\Projects\IWMS.Solutions\IWMS.Solutions.Client.Dashboard\Images\bbmp.png��6   6�   5(      �� 5)   
   $��BBMP's Dashboard��6   $
��Wrap=�6,   $
 Center=�6@   $��16(�6W   
�������$��1��6x   $��2��6�   ���	#FF16499A6�   B  <SoftArcs.WPFSmartLibrary.SmartUserControls.SmartLoginOverlay  5+   
   -   5          Name$ SmartLoginOverlayControl��5+   "   B  <SoftArcs.WPFSmartLibrary.FoundationTypes.AdvancedUserControl   FullSpan$ On=�5,      ���	#FF16499A   AdditionalSystemInfo$ Locked��52         UserName 5-      �� *
UserName+   Password 5.      �� *
Password+   AccessPassword 5/      �� *UserPassword+   UserImageSource 50      �� *UserImageSource+   AdditionalUserInfo 51      �� *MobileNumber+52      53      54      