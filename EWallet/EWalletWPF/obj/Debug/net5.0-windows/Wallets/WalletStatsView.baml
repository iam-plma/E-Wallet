   M S B A M L   `   `   `  ����E  AEWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EWalletWPF.WalletsEWalletWPF.Wallets  5      (    "EWalletWPF.Wallets.WalletStatsView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EWalletWPF.Wallets     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��50��6   $
��Auto �6+   6;   �� 5      $��30��6   $
��Auto �6+   6;   �� 5      $	��300��6   $
��Auto �6,   6<   �� 5      6   .+�5   
   �� $��0��6   $��4��6"   .+�5      �� $��10, 10, 10, 0q�6   $��Center=�6/   	Balance6U   �� 5      $	��300��6   $��10q�6%   $��Center=�61    �� 
IsReadOnly$
 True��6N   ��5      �� *	Balance+ �� UpdateSourceTrigger$ PropertyChanged=�6V   5      �� 5   
   $��1��6   $��0��6#   $��1��63   $��Right=�6G   .+�5      �� $��10, 10, 10, 0q�6   Last month Incomes6D   5      �� 5   
   $��1��6   $��1��6#   $��1��63   $
��Left=�6G   .+�5      �� $	��100��6   $��10q�6%   $
 True��62   ��5       �� *	IncomeSum+$ PropertyChanged=�6X   5!      �� 5#   
   $��1��6   $��2��6#   $��1��63   $��Right=�6G   .+�5$      �� $��10, 10, 10, 0q�6   Last month Expenses6E   5%      �� 5&   
   $��1��6   $��3��6#   $��1��63   $
��Left=�6G   .+�5'      �� $	��100��6   $��10q�6%   $
 True��62   ��5(      �� *ExpensesSum+$ PropertyChanged=�6Z   5)      �� 5+   
   $��2��6   $��2��6    ��64   �� *	Incomes+5-      �� 5/   
   $��2��6   $��2��6    $��2��60   ��6D   �� *
Expenses+51      �� 53   
   $��3��6   $��0��6"   $��4��62   $��50��6F   $��Bottom=�6S   $��Stretch=�6n   .+�54      �� -   5        $��BBack��54      $��18(�6"   $	��200��61   $	��400��6@   $��10,10,10,10q�6O   ��6d   �� *BackCommand+.��6�   Back6�   55      56      57      