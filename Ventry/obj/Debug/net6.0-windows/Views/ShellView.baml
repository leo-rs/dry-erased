   M S B A M L   `   `   `  ����A  =Ventry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Ventry.ViewsVentry.Views  5   	       Ventry.Views.ShellView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Ventry.Views     5   	     � Title$  	ShellView��5   	   $	��500��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5    
   �� $��1��6@   $��1��6M   ��6   ��  �� Path$ FullName� �� Mode$ OneWay=�6M   �� 5#   
   -   5         ��Name$ 	FirstName��5#   >   $	��100��6   $��2��6!   $��1��6.   6>   �� 5$   
   -   5        $ LastName��5$   >   $	��100��6   $��2��6!   $��2��6.   6>   �� 5'   
   -   5         ��Name$ People��5'   0   $��3��6   $��1��6     �� DisplayMemberPath$ 	FirstName��5)      	 �� SelectedItem	 5(      �� $ SelectedPerson�$ OneWayToSource=�5)      �� 5*   
   -   5        
 ��Name$
 SelectedPerson_LastName��5*   1   $��3��6   $��2��6!   61   �� 5-   
   -   5         ��Name$ 	ClearText��5-   .   $��4��6   $��1��6   .��6A   Clear Names6N   �� 50   
   -   5        $ LoadPageOne��50      $��5��6&   $��1��63   .��6C   Load First Page6T   �� 51   
   -   5        $ LoadPageTwo��51      $��5��6&   $��2��63   .��6C   Load Second Page6U   �� 54   
   -   5         ��Name$ 
ActiveItem��55      $��7��54      $��1��6&   $��5��66   55      57      58      