   M S B A M L   `   `   `  ����F  BProject_TAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TAB.ViewsProject_TAB.Views  5      ,    &Project_TAB.Views.TransactionAddWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Project_TAB.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � Title$  TransactionAddWindow��5      $��425.941��5	      $��546.396��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      � ���#F2B413.+�5   
   �� $��
109,22,0,0q�5      $
��Left=�5      $	��Top=�5      $��Dodawanie Transakcji��5      $��18(�5      $
��Bold"�5      �� 5   
   $��
146,61,0,0q�5      $
��Left=�5      $	��Top=�5      $��Nazwa��5      �� 5   
   -   5        $��	NameInput��5      $	��120��5      $��23��5       $��
146,87,0,0q�5!      $
��Left=�5"      $	��Top=�5#       �� TextWrapping$
 Wrap=�5$      �� 5&   
   $��146,119,0,0q�5'      $
��Left=�5(      $	��Top=�5)      $��Kwota��5*      �� 5+   
   -   5        $��AmountInput��5-      $	��120��5.      $��23��5/      $��146,145,0,0q�50      $
��Left=�51      $	��Top=�52      53      �� 55   
   $��146,179,0,0q�56      $
��Left=�57      $	��Top=�58      $
��Data��59      (  "System.Windows.Controls.DatePicker  5:   
   -   5        $��TransactionDatePicker��5;      $	��120��5<      $��146,205,0,0q�5=      $
��Left=�5>      $	��Top=�5?      �� 5A   
   $��146,244,0,0q�5B      $
��Left=�5C      $	��Top=�5D      $��Konto��5F      �� 5G   
   -   5        $��AccountsComboBox��5I      ���#F8D347$	��120��5J      $��146,270,0,0q�5K      $
��Left=�5L      $	��Top=�5M       �� DisplayMemberPath$ Account_Name��5N       �� SelectedValuePath$ Id��5P      ��5O      �� *userAccounts+5P      �� 5R   
   $��146,309,0,0q�5S      $
��Left=�5T      $	��Top=�5U      $��	Kategoria��5V      �� 5W   
   -   5        $��CategoriesComboBox��5X      $	��120��5Y      $��146,335,0,0q�5Z      $
��Left=�5[      $	��Top=�5\      $ Category_Name��5]      $ Id��5_      ��5^      �� *userCategories+5_      �� 5a   
   -   5        $��IncomeCheckBox��5b      $��153,380,0,0q�5c      $
��Left=�5d      $	��Top=�5e      $��Wpływ na konto��5f      �� 5h   
   -   5           ButtonStyle#���   5i      ���#F8D347$��75��5k      $��166,424,0,0q�5l      $
��Left=�5m      $	��Top=�5n      $��Dodaj��5p      5s      5t      