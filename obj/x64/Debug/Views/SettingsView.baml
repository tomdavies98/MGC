   M S B A M L   `   `   `  ����>  :MGC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MGC.Views	MGC.Views  5   	       MGC.Views.SettingsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MGC.Views     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   -   5          � WindowStartupLocation$  CenterScreen=�5
   	    � Title$ SettingsView��5   	   $	��450��6   $	��800��6+   
������  � WindowStyle$
 None=�5   	    � AllowsTransparency .  � 	Resources 5         
ComboStyle �� 
TargetType �� Property �� Value  
LabelStyle  CheckBoxStyle��%�  &	        &	 �     &	 0    �� 5   
   " ��6#   .�5      ��  � ��$ 0,18,0,0q�6'   �� 5       � ��$	 150��6&   �� 5       � ��
 ���� 6+   �� 5       � ��$ 15(�6)   �� 5       � ��$ 30��6'   5      �� 5   
   " ��6#   .�5      ��  � ��$ 	30,10,0,0q�6'   5      �� 5    
   " ��6&   .�5!      ��  � ��$ Center=�62   6C   5"      5#      .��5%      ��  �� CornerRadius$ 25��6   $��10q�6   ��5&   
   �� 5'      	 �� 
StartPoint$		 0,0&�6"   
 �� EndPoint$	
 1,1&�63   .��5(      �  � Offset$
 0.00Q�6    � Color$ #3f5efb��6-   � 5)      $
 0.14Q�6   $ #5b57f4��6-   � 5*      $
 0.28Q�6   $ #7551ed��6-   � 5+      $
 0.42Q�6   $ #7a53d5��6-   � 5,      $
 0.56Q�6   $ #7f54bf��6-   � 5-      $
 0.70Q�6   $ #7f53b8��6-   � 5.      $
 0.85Q�6   $ #7e51af��6-   � 5/      $
 1.00Q�6   $ #944ccf��6-   50      ._�52   
   � ��53      �� 54       � SpreadMethod$ Repeat=�6&    �� 	Transform 55      T� 56      -   5         LinearGradientBrushTranslate��56   -   ��59      � $
 0.00Q�6'   $ #3f5efb��65   � 5:      $
 0.14Q�6'   $ #5b57f4��65   � 5;      $
 0.28Q�6'   $ #7551ed��65   � 5<      $
 0.42Q�6'   $ #7a53d5��65   � 5=      $
 0.56Q�6'   $ #7f54bf��65   � 5>      $
 0.70Q�6'   $ #7f53b8��65   � 5?      $
 0.85Q�6'   $ #7e51af��65   � 5@      $
 1.00Q�6'   $ #944ccf��65   5B      .+�5E      ��  �� Orientation$ Vertical=�6   .+�5F      �� -   5        
������ $��Right=�5F   G   $��30��6c   $��25��6n   .��5G      �� 
������ X6=   5H      �� 5J      $	��350��6   $��Stretch=�6+   $��20(�6I   
������ $��20,0,0,0q�6p    5K       �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName��%R  '��       �� 5L      " ��6    .�5M      ��  � �� 5N   "   �� 5O   &   " ��66   .R�5P   *   �� $��Border��61   $��1,1,1,0q�6?   
�������$ 4,4,0,0��6q   $	��2,0q�6�   ._�5Q   .   �� $ ContentSite��6?   $��Center=�5R   )   $��Center=�5S   )   $��Header��5T   )   $
��10,2q�5U   )   5V   +    5W   *   P� 5X   .    �@��
IsSelected . . �5Y   2   �� $ Border��69    � �� �#944ccf6c   5Z   /   P� 5[   .    �@��
IsSelected .  . �5\   2   �� $ Border��69    � �� �#7551ed6c   5]   /   5_   '   5a      5b      5c      .@�5d      �� $��General Settings��6   $��Stretch=�68   .��5f      �� -   5        $��ScrollViewer3��5f   '   $
��Auto=�6<   $
��Auto=�6_   $	��300��6�   ��. .��5h      �� $ 
Horizontal=�6)   $	��Top=�6B   .+�5j   "   �� $ Vertical=�6-   .+�5l   &   �� #��[ 6,   $��File Output Directory��6P   $��18(�6p   6�   �� 5n   &   #��[ 6,   $��Recorder Mode��6P   $��18(�6h   6x   �� 5o   &   #��[ 6,   $��Notifications��6P   $��18(�6h   6x   �� 5p   &   #��[ 6,   $��Notification chimes��6P   $��18(�6n   6~   �� 5r   &   #��[ 6,   $��
Throttling��6P   $��18(�6e   6u   �� 5s   &   #��[ 6,   $��Hardware Encoding��6P   $��18(�6l   6|   �� 5t   &   #��[ 6,   $��Low Latency��6P   $��18(�6f   6v   �� 5u   &   #��[ 6,   $��Mp4 Fast Start��6P   $��18(�6i   6y   5v   #   �� 5w   "   $��10q�6,   
���   �6V   �� 5x   "   $ Vertical=�6-   .+�5z   &   �� $��	0, 15,0,0q�62   $ 
Horizontal=�6E   .+�5{   .   �� $��15(�68   $��Center=�6�   $��Center=�6�   ���#eaeaea$��25��6  $	��130��6  ��6F   �� *FileOutputDirectory+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . 6  �� 5|   .   $��1q�6h   ���#eaeaea$��20��6�   $��27��6�   $��Bottom=�6�   ��65   �� * OpenFileDirectorySearchCommand+.��5}   2   �� ��5~   6   H� 5   :    H� Drawing 5�   >   I� 5�   F    I� ClipGeometry4 ��        �     6n� 6n 6n� 6n    �        	.��5�   J   � 
 � Pen 5�   N   >� 5�   R    >� Brush �	#FF000000 >� 	Thickness$	 1.5Q�6h    >� StartLineCap$ Round=�6x    >� 
EndLineCap$ Round=�6�     >� LineJoin$  Round=�6�   ! � Geometry! 5�   N   @� 5�   R   " @� RadiusX$" 4Q�6b   # @� RadiusY$# 4Q�6n   $ @� Center$$ 15,15&�6z   5�   K   � 5�   J   +! �� 6n 6n�        РI�I�@o@@o@ 5�   N   >� 5�   R    �	#FF000000$	 1.5Q�6h   $ Round=�6x   $ Round=�6�   $  Round=�6�   5�   K   � 5�   J   +! �� 6n 6n�        � 	= ��[ � -1��[  5�   N   >� 5�   R    �	#FF000000$	 1.5Q�6h   $ Round=�6x   $ Round=�6�   $  Round=�6�   5�   K   � 5�   J   +! �� 6n 6n�        � 	=  � � z  �  5�   N   >� 5�   R    �	#FF000000$	 1.5Q�6h   $ Round=�6x   $ Round=�6�   $  Round=�6�   5�   K   � 5�   J   +! �� 6n 6n�        � 	= ��� z �� 5�   N   >� 5�   R    �	#FF000000$	 1.5Q�6h   $ Round=�6x   $ Round=�6�   $  Round=�6�   5�   K   5�   G   5�   ?   5�   3   5�   /   5�   '   �� 5�   &   #��[  6/   % �� SelectedValue% 6S   �� *SelectedRecorderMode+$ PropertyChanged=� . ��6�   �� *RecorderModes+$ PropertyChanged=� . 6,  �� 5�   &   #��[ 6/   $��
10, 20,0,0q�6�   $��Center=�6�   & d� 	IsChecked& 6V   �� *NotificationsEnabled+$ PropertyChanged=� . 6�   �� 5�   &   #��[ 6/   $��10, 25,0,10q�6�   $��Center=�6�   & 6V   �� *NotificationsChimes+$ PropertyChanged=� . 6�   �� 5�   &   #��[ 6/   $��
10, 20,0,0q�6�   $��Center=�6�   & 6V   �� *ThrottlingEnabled+$ PropertyChanged=� . 6�   �� 5�   &   #��[ 6/   $��
10, 30,0,0q�6�   $��Center=�6�   & 6V   �� *HardwareEncoding+$ PropertyChanged=� . 6�   �� 5�   &   #��[ 6/   $��
10, 35,0,0q�6�   $��Center=�6�   & 6V   �� *
LowLatency+$ PropertyChanged=� . 6�   �� 5�   &   #��[ 6/   $��
10, 30,0,0q�6�   $��Center=�6�   & 6V   �� *Mp4FastStart+$ PropertyChanged=� . 6�   5�   #   5�      5�      5�      �� 5�      $��Video Settings��6   .��5�      �� $ 
Horizontal=�6%   $	��Top=�6>   .+�5�      �� $ Vertical=�6)   .+�5�   "   �� #��[ 6(   $��Fixed Frame Rate��6L   $��18(�6g   6w   �� 5�   "   #��[ 6(   $��Quality��6L   $��18(�6^   6n   �� 5�   "   #��[ 6(   $��Bitrate Mode��6L   $��18(�6c   6s   �� 5�   "   #��[ 6(   $��Bitrate��6L   $��18(�6^   6n   �� 5�   "   #��[ 6(   $��
Frame Rate��6L   $��18(�6a   6q   �� 5�   "   #��[ 6(   $��Encoder Profile��6L   $��18(�6f   6v   5�      �� 5�      $��10q�6(   
���   �6R   �� 5�      $ Vertical=�6)   .+�5�   "   �� #��[ 6+   $��	0, 25,0,0q�6�   $��Center=�6�   & 6R   �� *FixedFrameRate+$ PropertyChanged=� . 6�   �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $	��110��6-   $��Bottom=�6�   $��20��6�   $��0,0,0,0q�6�   ' � Maximum$	' 100Q�6�   ( � Value( 69   �� *VideoQuality+$ TwoWay=�$ PropertyChanged=� . 6�   �� 5�   &   
������ $��	1, 15,0,0q�6I   $��Center=�6\   $��Center=�6y   $��40��6�   ��6�   �� *VideoQuality+$ PropertyChanged=� . 5�   #   �� 5�   "   #��[  6+   $��Center=�6O   % 6l   �� *SelectedVideoBitrateMode+$ PropertyChanged=� . ��6�   �� *VideoBitrateModes+$ PropertyChanged=� . 6M  �� 5�   "   $��	0, 18,0,0q�6*   $��15(�6=   $��30��6K   $��Center=�6�   $��Center=�6�   ���#eaeaea$	��150��6  ��6W   �� *BitrateValue+$ TwoWay=�$ PropertyChanged=� . 6  �� 5�   "   #��[  6+   $��0,15,0,0q�6O   $��Center=�6a   % 6~   �� *SelectedFrameRate+$ PropertyChanged=� . ��6�   �� *
FrameRates+$ PropertyChanged=� . 6Q  �� 5�   "   #��[  6+   $��	0, 14,0,0q�6�   % 6O   �� *SelectedEncoderProfile+$ PropertyChanged=� . ��6�   �� *EncoderProfile+$ PropertyChanged=� . 6>  5�      5�      5�      �� 5�      $��Audio Settings��6   .��5�      �� -   5        $��ScrollViewer1��5�   '   $
��Auto=�6<   $
��Auto=�6_   $	��300��6�   ��. .��5�      �� $ 
Horizontal=�6)   $	��Top=�6B   .+�5�   "   �� $ Vertical=�6-   .+�5�   &   �� #��[ 6,   $��Input Enabled��6P   $��18(�6h   6x   �� 5�   &   #��[ 6,   $��Output Enabled��6P   $��18(�6i   6y   �� 5�   &   #��[ 6,   $��Audio Enabled��6P   $��18(�6h   6x   �� 5�   &   #��[ 6,   $��
Microphone��6P   $��18(�6e   6u   �� 5�   &   #��[ 6,   $��Input Volume��6P   $��18(�6g   6w   �� 5�   &   #��[ 6,   $��Output Volume��6P   $��18(�6h   6x   �� 5�   &   #��[ 6,   $��Bitrate��6P   $��18(�6b   6r   �� 5�   &   #��[ 6,   $��Channels��6P   $��18(�6c   6s   �� 5�   &   #��[ 6,   $��Audio Output��6P   $��18(�6g   6w   5�   #   �� 5�   "   $��10q�6,   
���   �6V   �� 5�   "   $ Vertical=�6-   .+�5�   &   �� #��[ 6/   $��	0, 20,0,0q�6�   $��Center=�6�   & 6V   �� *AudioInputEnabled+$ PropertyChanged=� . 6�   �� 5�   &   #��[ 6/   $��	0, 20,0,0q�6�   $��Center=�6�   & 6V   �� *AudioOutputEnabled+$ PropertyChanged=� . 6�   �� 5�   &   #��[ 6/   $��0,29,0,0q�6�   $��Center=�6�   & 6V   �� *AudioEnabled+$ PropertyChanged=� . 6�   �� 5�   &   #��[  6/   $��0,19,0,0q�6S   ) �� SelectedItem) 6e   �� *SelectedInputDevice+$ PropertyChanged=� . ��6�   �� *InputDevices+$ PropertyChanged=� . 6;  �� 5�   &   $ 
Horizontal=�61   $��Center=�6J   .+�5�   *   �� $	��110��61   $��Bottom=�6�   $��20��6�   $��0,0,0,0q�6�   $	' 100Q�6�   ( 6=   �� *AudioInputVolume+$ TwoWay=�$ PropertyChanged=� . *  $Microsoft.Xaml.Behaviors.Interaction*   Triggers* 5�   .   +  %Microsoft.Xaml.Behaviors.EventTrigger  5�   2   +   	EventName$+ ValueChanged��6A   *  $Microsoft.Xaml.Behaviors.TriggerBase,   Actions., 5�   6   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  -   Command- 6L   �� *InputVolumeValueChanged+5�   3   5�   +   �� 5�   *   
������ $��	1, 15,0,0q�6M   $��Center=�6`   $��Center=�6}   $��40��6�   ��6�   �� *AudioInputVolume+$ PropertyChanged=� . 5�   '   �� 5�   &   $ 
Horizontal=�61   $��Center=�6J   .+�5�   *   �� $	��110��61   $��Bottom=�6�   $��20��6�   $��0,0,0,0q�6�   $	' 100Q�6�   ( 6=   �� *AudioOutputVolume+$ TwoWay=�$ PropertyChanged=� . 6�   �� 5�   *   
������ $��	1, 15,0,0q�6M   $��Center=�6`   $��Center=�6}   $��40��6�   ��6�   �� *AudioOutputVolume+$ PropertyChanged=� . 5   '   �� 5  &   #��[  6/   $��Center=�6S   ) 6p   �� *SelectedAudioBitrate+$ PropertyChanged=� . ��6�   �� *AudioBitrates+$ PropertyChanged=� . 6H  �� 5  &   #��[  6/   $��Center=�6S   ) 6p   �� *SelectedAudioChannel+$ PropertyChanged=� . ��6�   �� *AudioChannels+$ PropertyChanged=� . 6H  �� 5  &   #��[  6/   $��Center=�6S   ) 6p   �� *SelectedOutputDevice+$ PropertyChanged=� . ��6�   �� *OutputDevices+$ PropertyChanged=� . 6H  5  #   5     5     5	     �� 5
     $��Macros��6   5     5     �� 5     $ 
Horizontal=�6   $��Right=�66    5     . �� Color/ J� Effect3  -System.Windows.Media.Effects.DropShadowEffect0   Color1   ShadowDepth��%�  '��       �� 5     " ��6    .�5     ��  � ��$ 	10,10,0,0q�67   �� 5      � �� 5  "   �� 5  &   $. #eb0bf4��66   5     �� 5      � �� 5  "   �� 5  &   " ��66   .R�5  *   �� #��z��61   $	��0.8q�6]   $ 3��6s   / 5  .     5  2   $0 	#FF72FFE5��6C   $1 0Q�6U   ._�5  .   �� #��z��68   #��z��6c   $��Center=�6�   $��Center=�6�   5  +   5   '   5"     5#     5$     .+�5%     �� $��80��6>   $��	10,10,0,0q�6I   $
��Save��6\   $��30(�6k   ��6   �� *SaveSettings+6k   �� 5&     $��80��6?   $��
10,10,10,0q�6J   $��Reset��6^   $��30(�6n   ��6   �� *ResetSettings+6n   5(     5)     5*     5+     5,     