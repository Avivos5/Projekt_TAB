   M S B A M L   `   `   `  ����F  BProject_TAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TAB.ViewsProject_TAB.Views  5      &     Project_TAB.Views.AccountsWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Project_TAB.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  AccountsWindow��5      $	��800��5	      $	��450��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      � ���#F2B413.+�5   
   �� $��	94,45,0,0q�5      $
��Left=�5      $	��Top=�5      $��Aktywne Konta��5      $
��Bold"�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ AccountsDatagrid��5         
IsReadOnly . $��
0,76,440,0q�5         AutoGenerateColumns .     CanUserAddRows .     RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5      �� 5       	 �� Binding	 6&   �� *Status+
 �� Value
 true6A   .a�5!      ��  �� Property � �� �� Value �#fff6;   5"      �� 5#      	 6&   �� *Status+	
 false6A   .a�5$      ��  � �� �#aaa6;   5%      5'         Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa��6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ Account_Name�6K     5,      $ Balans (zł)��6F    6%   �� $ Balance�6F   4  .System.Windows.Controls.DataGridTemplateColumn  5-      $
 Edit��6)      CellTemplate 5.      �� 5/      .R�50      �� -   5        $
��Edit��50   8   51      53      56      �� 59   
   $��
560,45,0,0q�5:      $
��Left=�5;      $	��Top=�5<      $��Niekatywne Konta��5=      $
��Bold"�5>        5@   
   -   5        $ InactiveAccountsDatagrid��5C       . $��
440,76,0,0q�5D       .   .   5G      �� 5H      "  6    5I      �� 5J      	 6&   �� *Status+
 true6A   .a�5K      ��  � �� �#fff6;   5L      �� 5M      	 6&   �� *Status+	
 false6A   .a�5N      ��  � �� �#aaa6;   5O      5Q       5T        5U      $ Nazwa��6K    6%   �� $ Account_Name�6K     5V      $ Balans (zł)��6F    6%   �� $ Balance�6F     5W      $
 Edit��6)    5X      �� 5Y      .R�5Z      �� -   5        $
��Edit��5Z   @   5[      5]      5`      �� 5b   
   -   5        $��WelcomeLabel��5c      $��19,6,0,0q�5d      $
��Left=�5e      $	��Top=�5f      $��Konta��5g      $
��Bold"�5h      �� 5i   
   -   5           ButtonStyle#���   5j      ���#F8D347$	��106��5l      $��
212,10,0,0q�5m      $
��Left=�5n      $	��Top=�5o      $��Dodaj Konto��5q      �� 5t   
   -   5        #���   5u      ���#F8D347$��75��5w      $��
454,10,0,0q�5x      $
��Left=�5y      $	��Top=�5z      $��
Transakcje��5|      �� 5~   
   -   5        #���   5      ���#F8D347$��75��5�      $��
707,10,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Wyloguj��5�      5�      5�      