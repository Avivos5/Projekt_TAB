   M S B A M L   `   `   `  ����F  BProject_TAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TAB.ViewsProject_TAB.Views  5      -    'Project_TAB.Views.TransactionEditWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Project_TAB.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � Title$  TransactionEditWindow��5      $��425.941��5	      $��546.396��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      � ���#F2B413.+�5   
   �� $��
134,22,0,0q�5      $
��Left=�5      $	��Top=�5      $��Edycja Transakcji��5      $��18(�5      $
��Bold"�5      �� 5   
   $��
146,61,0,0q�5      $
��Left=�5      $	��Top=�5      $��Nazwa��5      �� 5   
   -   5        $��	NameInput��5       $	��120��5!      $��23��5"      $��
146,87,0,0q�5#      $
��Left=�5$      $	��Top=�5%       �� TextWrapping$
 Wrap=�5&      �� 5(   
   $��146,119,0,0q�5)      $
��Left=�5*      $	��Top=�5+      $��Kwota��5,      �� 5-   
   -   5        $��AmountInput��5/      $	��120��50      $��23��51      $��146,145,0,0q�52      $
��Left=�53      $	��Top=�54      55      �� 57   
   $��146,179,0,0q�58      $
��Left=�59      $	��Top=�5:      $
��Data��5;      (  "System.Windows.Controls.DatePicker  5<   
   -   5        $��TransactionDatePicker��5>      ���#F8D347$	��120��5?      $��146,205,0,0q�5@      $
��Left=�5A      $	��Top=�5B      �� 5D   
   $��146,244,0,0q�5E      $
��Left=�5F      $	��Top=�5G      $��Konto��5H      �� 5I   
   -   5        $��AccountsComboBox��5K      ���#F8D347$	��120��5L      $��146,270,0,0q�5M      $
��Left=�5N      $	��Top=�5O       �� DisplayMemberPath$ Account_Name��5P       �� SelectedValuePath$ Id��5R      ��5Q      �� *userAccounts+5R      �� 5T   
   $��146,309,0,0q�5U      $
��Left=�5V      $	��Top=�5W      $��	Kategoria��5X      �� 5Y   
   -   5        $��CategoriesComboBox��5[      ���#F8D347$	��120��5\      $��146,335,0,0q�5]      $
��Left=�5^      $	��Top=�5_      $ Category_Name��5`      $ Id��5b      ��5a      �� *userCategories+5b      �� 5d   
   -   5        $��IncomeCheckBox��5e      $��153,380,0,0q�5f      $
��Left=�5g      $	��Top=�5h      $��Wpływ na konto��5i      �� 5k   
   -   5           ButtonStyle#���   5l      ���#F8D347$��75��5n      $��166,424,0,0q�5o      $
��Left=�5p      $	��Top=�5q      $��Edytuj��5s      5v      5w      