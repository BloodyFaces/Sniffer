   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   B >Sniffer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Sniffer.ViewsSniffer.Views 5   	      Sniffer.Views.CaptureView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _iePclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   -localclr-namespace:Sniffer.Views     5   	   $��3q�5	   	   
���   ����#8E9DA1  � Title$  CaptureView��5   	   $	��800��6   $
��1280��6*    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M   .��5      � .+�5   
   �� -   5        $
��List��5      $��36,56,616,317q�6   $��Stretch=�6U   $��Stretch=�6z   ��65   �� *	Packets+��5      �� 5      .R�5      � $	��0,2q�6    � RowDefinitions 5      �� 5       � ColumnDefinitions 5      �� 5      $��* �6/   6;   �� 5      $��20 �6/   6<   �� 5      $��* �6/   6;   �� 5      $��20 �6/   6<   �� 5      $��* �6/   6;   .+�5      �� $��24(�6>   $��0��6L   ��6$   �� *
Position+6L   �� 5      $��24(�6<   $��2��6J   ��6$   �� *Length+6J   �� 5      $��24(�6:   $��4��6H   ��6$   �� *Time+6H   5      5       .   (System.Windows.Interactivity.Interaction   Triggers 5"      /   )System.Windows.Interactivity.EventTrigger  5#         	EventName$ SelectionChanged��6"   .   (System.Windows.Interactivity.TriggerBase   Actions. 5$      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6-   �� *SelectionChangedCommand+	   CommandParameter	 6Y   �� 
 �� ElementName$

 List�� �� Path$ SelectedIndex�5%      5'      �� 5(   
    �� TextWrapping$
 Wrap=�6   $��36,457,616,67q�6&    �� 
IsReadOnly . $��24(�6h   ��6=   �� *	Details+6h   �� 5)   
   $��Start capturing��6   $
��Left=�6+   $��808,628,0,0q�6F   $	��Top=�6[   $	��201��6s   $��70��6   $��24(�6�   ��6�   �� *CaptureStartCommand+6�   �� 5*   
   $��Stop capturing��6   $
��Left=�6*   $��1014,628,0,0q�6E   $	��Top=�6[   $	��211��6s   $��70��6   $��24(�6�   ��6�   �� *CaptureStopCommand+6�   �� 5+   
   $
��Left=�6   $	��567��6-   $��
661,56,0,0q�6:   $
 Wrap=�6N   $	��Top=�6b   $	��564��6z    . $��14(�6�   ��6�   �� *
HexDetails+6�   �� 5,   
   $��Clean��6   $
��Left=�6!   $��661,628,0,0q�6<   $	��Top=�6Q   $	��142��6i   $��70��6u   $��24(�6�   ��6�   �� *CleanCommand+6�   5-      5.      