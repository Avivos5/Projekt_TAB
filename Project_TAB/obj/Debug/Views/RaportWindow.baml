   M S B A M L   `   `   `  ����F  BProject_TAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TAB.ViewsProject_TAB.Views  5      $    Project_TAB.Views.RaportWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Project_TAB.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � Title$  RaportWindow��5      $	��486��5	      $	��458��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      � ���#F2B413$��0,0,0,0q�6     � RowDefinitions 5   
   �� 5      $��0* �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $	��98* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ CategoriesDatagrid��5      $��4,26,0,0q�5         AutoGenerateColumns .     CanUserAddRows .  $
��Left=�5   D   $	��161��6_   $��1��6k      MinColumnWidth$ 20Q�6{      MaxColumnWidth$	 140Q�6�   $	��337��6�   $	��Top=�6�   $��1��6�   	   RowStyle	 5      �� 5      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   5!         Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Category_Name+6G   4  .System.Windows.Controls.DataGridCheckBoxColumn  5'      $
 Uzyj��5)         IsThreeState .   5(      �� *Category_Selected+5*      5-      �� 5.   
   -   5        $��1��5/      $	��102��50      $��350,105,0,0q�51      $
��Left=�52      $	��Top=�53      ���#F8D347$��Generuj��56       J� RenderTransformOrigin$ 	0.49,0.45&�57         ButtonStyle#���   58      $��1��63   $��20��6@   �� 59   
   -   5        $	��161��5:      $��	4,368,0,0q�5;      $
��Left=�5<      $	��Top=�5=      ���#F8D347$��Zaznacz wszystko��5@      #���   5A      $��21��63   $��1��6?   $��1��6L   �� 5B   
   -   5        $	��161��5C      $��	4,389,0,0q�5D      $
��Left=�5E      $	��Top=�5F      ���#F8D347$��Odznacz wszystko��5I      $ 0.499,0.433&�5J      #���   5K      $��20��63   $��1��6?   $��1��6L   �� 5L   
   $��1��5M      $��92��5N      $��28��5O      $��	342,0,0,0q�5P      $
��Left=�5Q      $	��Top=�5R      $��Początek
��5S      $ 1.152,0.071&�6*   $��1��6N   (  "System.Windows.Controls.DatePicker  5T   
   -   5          Name$ datePicker1��5U      $��1��5V      $	��120��5W      $��
342,26,0,0q�5X      $
��Left=�5Y      $	��Top=�5Z      $��24��6%   $��1��61   �� 5[   
   $��1��5\      $	��115��5]      $��
342,50,0,0q�5^      $
��Left=�5_      $	��Top=�5`      $��Koniec��5a      $��1��6   $��26��6+     5b   
   -   5        $ datePicker2��5c      $��1��5d      $	��120��5e      $��
342,76,0,0q�5f      $
��Left=�5g      $	��Top=�5h      $��1��6%   $��24��62   �� 5i   
   $��1��5j      $��	174,2,0,0q�5k      $
��Left=�5l      $	��Top=�5m      $��Konta��5n      $ -1,1.308&�6   $��26��6>   $��41��6J   $��1��6U     5o   
   -   5        $ AccountsDatagrid��5p      $��
170,26,0,0q�5q       .   .  $	��337��5t   D   $	��Top=�6Q   $��1��6i   $
��Left=�6y   $	��165��6�   $ 20Q�6�   $	 140Q�6�   $��1��6�   	 5u      �� 5v      "
  6   5x       5{        5|      $ Nazwa��6F    6%   �� *Account_Name+6F     5~      $
 Uzyj��5�       .   5      �� *Account_Selected+5�      5�      �� 5�   
   -	   5        $	��159��5�      $��174,368,0,0q�5�      $
��Left=�5�      $	��Top=�5�      ���#F8D347$��Zaznacz wszystko��5�      #���   5�      $��21��63   $��1��6?   $��1��6O   �� 5�   
   -
   5        $	��159��5�      $��174,389,0,0q�5�      $
��Left=�5�      $	��Top=�5�      ���#F8D347$��Odznacz wszystko��5�      $ 	0.497,0.5&�5�      #���   5�      $��20��63   $��1��6?   $��1��6O   �� 5�   
   $��4,0,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��	Kategorie��5�      $ 	0.5,0.462&�6!   $��1��6C   $��26��6S   $��60��6_   $��1��6j   5�      5�      