   M S B A M L   `   `   `  ����F  BProject_TAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TAB.ViewsProject_TAB.Views  5      "    Project_TAB.Views.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Project_TAB.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  Budzet domowy��5	       � 
ResizeMode$ NoResize=�5
      $	��800��5      $	��450��5       � WindowStartupLocation$ CenterScreen=�5      .��5      � ���#F2B413 � ColumnDefinitions 5   
   �� 5      $	��23* �6   �� 5      $
��177* �6   .+�5   
   �� -   5        $��WelcomeLabel��5      $��	52,11,0,0q�5      $
��Left=�5      $	��Top=�5      $��
*UserName*��5      $
��Bold"�5      $��2��6   �� 5    
   -   5        $��TotalBalance��5!      $��	74,10,0,0q�5"      $
��Left=�5#      $	��Top=�5$      $!��Główny Balans: XXXX (zł)��5%      $
��Bold"�5&      $��1��6   �� 5(   
   -   5           ButtonStyle#���   5)      ���#F8D347$	��106��5+      $��
268,14,0,0q�5,      $
��Left=�5-      $	��Top=�5.      $��Dodaj Transakcje��50      $��1��6(   �� 52   
   -   5        #���   53      ���#F8D347$��74��55      $��
379,14,0,0q�56      $
��Left=�57      $	��Top=�58      $��	Kategorie��5:      $��1��6!   �� 5<   
   -   5        #���   5=      ���#F8D347$��75��5?      $��
458,14,0,0q�5@      $
��Left=�5A      $	��Top=�5B      $��Konta��5D      $��1��6   �� 5F   
   -   5        #���   5G      ���#F8D347$��36��5I      $��	643,4,0,0q�5J      $
��Left=�5K      $	��Top=�5L   )   $��1��6A   $��37��6Q   .��5M      �� $��/Assets/logout.png��6   62   5N      &   System.Windows.Controls.DataGrid  5Q   
   -   5          Name$ TransactionsDatagrid��5S         
IsReadOnly . $��	40,46,0,0q�5T         AutoGenerateColumns .     CanUserAddRows .  $��1��5V   $      RowStyle 5W      �� 5X      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   
 �� Triggers
 5Y      �� 5Z       �� Binding 6&   �� *Income+ �� Value	 false6A   .a�5[      ��  �� Property � �� �� Value �#f7bbb76;   5\      �� 5]       6&   �� *Income+ true6A   .a�5^      ��  � �� �#bdf7b76;   5_      5a         Columns 5d      0  *System.Windows.Controls.DataGridTextColumn  5e      ,  &System.Windows.Controls.DataGridColumn   Header$
 Data��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ DateTime�6G     5f      $ Nazwa��6C    6%   �� $
 Name�6C     5g      $ 	Kategoria��6L    6%   �� $ Category_Name�6L     5h      $ Konto��6K    6%   �� $ Account_Name�6K     5i      $  Wartość transakcji (zł)��6Q    6%   �� $ Transaction_Amount�6Q   4  .System.Windows.Controls.DataGridTemplateColumn  5j      $ Delete��6)      CellTemplate 5k      �� 5l      .R�5m      �� -   5        $��Delete��5m   :   5n      5p        5r      $
 Edit��6)    5s      �� 5t      .R�5u      �� -	   5        $
��Edit��5u   8   5v      5x      5z      �� 5|   
   $	��108��5}      $��	19,86,0,0q�5~      $
��Left=�5      $	��Top=�5�      $��	Kategorie��5�      $��2��6!   �� 5�   
   -
   5        $��Categories_ComboBox��5�      $	��103��5�      $��
19,117,0,0q�5�      $
��Left=�5�      $	��Top=�5�       �� DisplayMemberPath$ Category_Name��5�       �� SelectedValuePath$ Id��5�      $��2��6$   ��5�      �� *userCategories+5�   $   �� 5�   
   $��79��5�      $��
19,144,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Konto��5�      $��2��6   �� 5�   
   -   5        $��Accounts_ComboBox��5�      $	��103��5�      $��
19,170,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $ Account_Name��5�      $ Id��5�      $��2��6$   ��5�      �� *userAccounts+5�   $   �� 5�   
   -   5        #���   5�      ���#F8D347$��75��5�      $��
29,335,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Filtruj��5�      $��2��6   �� 5�   
   -   5        #���   5�      ���#F8D347$��75��5�      $��29,365,0,10q�5�      $
��Left=�5�      $��Resetuj��5�      $��2��6   �� 5�   
   $��	29,55,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��	FILTRACJA��5�      $
��Bold"�5�      $��2��6   �� 5�   
   $
��Od
��6   $
��Left=�6'   $��
18,202,0,0q�6B   $	��Top=�6V   �� 5�   
   $
��Do
��6   $
��Left=�6'   $��
19,268,0,0q�6B   $	��Top=�6V   (  "System.Windows.Controls.DatePicker  5�   
   -   5          Name$ datePicker1��5�      $
��Left=�6*   $��
19,236,0,0q�6E   $	��Top=�6Y    J� RenderTransformOrigin$ -0.096,0.21&�6q   $��2��6�     5�   
   -   5        $ datePicker2��5�      $
��Left=�6*   $��
19,302,0,0q�6E   $	��Top=�6Y   $��2��6q   �� 5�   
   -   5        #���   5�      ���#F8D347$��Raport��6L   $��1��6]   $
��Left=�6m   $��
538,14,0,0q�6�   $	��Top=�6�   $��74��6�   6�   �� 5�   
   $��/Assets/user-icon.png��6   $
��Left=�6/   $��28��6J   $��19,9,0,0q�6V   $	��Top=�6h   $��28��6�   5�      5�      