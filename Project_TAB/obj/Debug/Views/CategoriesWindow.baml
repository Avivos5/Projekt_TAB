   M S B A M L   `   `   `  ����F  BProject_TAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TAB.ViewsProject_TAB.Views  5      (    "Project_TAB.Views.CategoriesWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Project_TAB.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  CategoriesWindow��5      $	��800��5	      $	��450��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      � ���#F2B413.+�5   
   �� $��	94,45,0,0q�5      $
��Left=�5      $	��Top=�5      $��Aktywne Kategorie��5      $
��Bold"�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CategoriesDatagrid��5         
IsReadOnly . $��
0,76,440,0q�5         AutoGenerateColumns .     CanUserAddRows .     RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5      �� 5      	 �� Binding	 6&   �� *Status+
 �� Value
 true6A   .a�5      ��  �� Property � �� �� Value �#fff6;   5       �� 5!      	 6&   �� *Status+	
 false6A   .a�5"      ��  � �� �#aaa6;   5#      5%         Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa��6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ Category_Name�6L   4  .System.Windows.Controls.DataGridTemplateColumn  5*      $
 Edit��6)      CellTemplate 5+      �� 5,      .R�5-      �� -   5        $
��Edit��5-   8   5.      50      53      �� 56   
   $��
560,45,0,0q�57      $
��Left=�58      $	��Top=�59      $��Niekatywne Kategorie��5:      $
��Bold"�5;        5=   
   -   5        $  InactiveCategoriesDatagrid��5?       . $��
440,76,0,0q�5@       .   .   5C      �� 5D      "  6    5E      �� 5F      	 6&   �� *Status+
 true6A   .a�5G      ��  � �� �#fff6;   5H      �� 5I      	 6&   �� *Status+	
 false6A   .a�5J      ��  � �� �#aaa6;   5K      5M       5P        5Q      $ Nazwa��6L    6%   �� $ Category_Name�6L     5R      $
 Edit��6)    5S      �� 5T      .R�5U      �� -   5        $
��Edit��5U   @   5V      5X      5[      �� 5]   
   -   5        $��WelcomeLabel��5^      $��19,6,0,0q�5_      $
��Left=�5`      $	��Top=�5a      $��	Kategorie��5b      $
��Bold"�5c      �� 5d   
   -   5           ButtonStyle#���   5e      ���#F8D347$	��106��5g      $��
212,10,0,0q�5h      $
��Left=�5i      $	��Top=�5j      $��Dodaj Kategorię��5l      �� 5o   
   -   5        #���   5p      ���#F8D347$��75��5r      $��
454,10,0,0q�5s      $
��Left=�5t      $	��Top=�5u      $��
Transakcje��5w      �� 5y   
   -   5        #���   5z      ���#F8D347$��75��5|      $��
707,10,0,0q�5}      $
��Left=�5~      $	��Top=�5      $��Wyloguj��5�      5�      5�      