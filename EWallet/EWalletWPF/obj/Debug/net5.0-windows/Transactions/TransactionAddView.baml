   M S B A M L   `   `   `  ����E  AEWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:EWalletWPF.TransactionsEWalletWPF.Transactions  5      0    *EWalletWPF.Transactions.TransactionAddView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:EWalletWPF.Transactions     5      {�5      �� *	IsEnabled+.��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   �� $��0��6   $��2��6"   .+�5      �� $��10, 10, 10, 0q�6   Date65   �� 5      $	��300��6   $��10q�6%   $��Stretch=�61   ��5      �� *
DateTime+ �� UpdateSourceTrigger$ PropertyChanged=�6W   5      �� 5   
   $��1��6   $��2��6"   .+�5      �� $��10, 10, 10, 0q�6   Description6<   �� 5      $	��300��6   $��10q�6%   $��Stretch=�61   ��5      �� *Description+$ PropertyChanged=�6Z   5      �� 5    
   $��2��6   $��2��6"   .+�5!      �� $��10, 10, 10, 0q�6   Sum64   �� 5"      $	��300��6   $��10q�6%   $��Stretch=�61   ��5#      �� *Sum+$ PropertyChanged=�6R   5$      �� 5%   
   $��3��6   $��2��6"   .+�5&      �� $��10, 10, 10, 0q�6   
Currency69   �� 5'      -   5        $��Currency��5'      $	��300��6'   $��10q�66   $��Stretch=�6B    �� Text 6`   �� *
Currency+$ PropertyChanged=�.@�5(      �� UAH6!   �� 5)      USD6!   �� 5*      EUR6!   5+      5,      �� 5-   
   $��4��6   $��Bottom=�6"   .+�5.      �� -   5        $��BAddTransaction��5.      $��18(�6,   $	��200��6;   $	��400��6J   $��10,10,10,10q�6Y   ��6n   �� *CreateTransactionCommand+.��6�   Add Transaction6�   5/      �� 50   
   $��5��6   $��1��6"   $��Bottom=�62   .+�51      �� -   5        $��BBack��51      $��18(�6"   $	��200��61   $	��400��6@   $��10,10,10,10q�6O   ��6d   �� *BackCommand+.��6�   Back6�   52      53      54      