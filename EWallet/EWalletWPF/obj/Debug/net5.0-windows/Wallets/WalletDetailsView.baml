   M S B A M L   `   `   `  ����E  AEWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EWalletWPF.WalletsEWalletWPF.Wallets  5      A%clr-namespace:EWalletWPF.TransactionsEWalletWPF.Transactions  5      *    $EWalletWPF.Wallets.WalletDetailsView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EWalletWPF.Wallets     5      >transactions%clr-namespace:EWalletWPF.Transactions     5        � 	Resources  5
       �� DataType7  1EWalletWPF.Transactions.BasicTransactionViewModel2   ,EWalletWPF.Transactions.BasicTransactionView-   'EWalletWPF.Wallets.WalletStatsViewModel(   "EWalletWPF.Wallets.WalletStatsView��%�   (��       5      *, +)(�� 7     5      *, +)�� 5   
   "  6   .R�5        62   5      �� 5   
   "  6   .R�5        6&   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5    
   �� $��0��6   $��2��6"   .+�5!      �� $��10, 10, 10, 0q�6   Name65   �� 5"      $	��300��6   $��10q�6%   $��Stretch=�61   ��5#      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6S   5$      �� 5%   
   $��1��6   $��2��6"   .+�5&      �� $��10, 10, 10, 0q�6   Description6<   �� 5'      $	��300��6   $��10q�6%   $��Stretch=�61   ��5(      �� *Description+$ PropertyChanged=�6Z   5)      �� 5*   
   $��2��6   $��2��6"   .+�5+      �� $��10, 10, 10, 0q�6   	Balance68   �� 5,      $	��300��6   $��10q�6%   $��Stretch=�61    �� 
IsReadOnly$
 True��6O   ��5-      �� *	Balance+$ PropertyChanged=�6V   5.      �� 5/   
   $��3��6   $��2��6"   .+�50      �� $��10, 10, 10, 0q�6   
Currency69   �� 51      -   5        $��Currency��51      $	��300��6'   $��10q�66   $��Stretch=�6B    �� Text 6`   �� *
Currency+$ PropertyChanged=�.@�52      �� UAH6!   �� 53      USD6!   �� 54      EUR6!   55      56      �� 57   
   $��4��6   $	��140��6"   $��2��62   .+�58      �� $��10, 10, 10, 10q�6   
Categories6<   �� 59      $��1��6   $	��100��6(   ��69   �� *
Categories+5;      5<      �� 5=   
   $��5��6   $��2��6"   $��Bottom=�66   .+�5>      �� -   5        $��BWalletInfo��5>      $��18(�6(   $	��200��67   $	��400��6F   $��10,10,10,10q�6U   ��6j   �� *StatsCommand+.��6�   Wallet Last month Stats6�   5?      �� 5@   
   $��6��6   $��0��6"   $��Bottom=�62   .+�5A      �� -   5        $��BTransactions��5A      $��18(�6*   $	��200��69   $	��400��6H   $��10,10,10,10q�6W   ��5B      �� *TransactionsCommand+.��6=   Transactions6K   5C      �� 5E   
   $��6��6   $��1��6"   $��Bottom=�62   .+�5F      �� -   5        $��BDeleteWallet��5F      $��18(�6*   $	��200��69   $	��400��6H   $��10,10,10,10q�6W   ��6l   �� *DeleteWalletCommand+.��6�   Delete Wallet6�   5G      5H      5I      