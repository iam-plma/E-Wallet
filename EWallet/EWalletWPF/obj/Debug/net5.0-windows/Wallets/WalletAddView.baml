   M S B A M L   `   `   `  ����E  AEWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EWalletWPF.WalletsEWalletWPF.Wallets  5      &     EWalletWPF.Wallets.WalletAddView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EWalletWPF.Wallets     5        � 	Resources  5	       �� DataType8   2EWalletWPF.Wallets.ChooseWalletCategoriesViewModel3   -EWalletWPF.Wallets.ChooseWalletCategoriesView��%L   (��       5
      *, +)�� 6
   "  6   .R�5        61   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100��6   60   �� 5      $��2 �6   6+   �� 5      $��3* �6   6,    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   �� $��0��6   $��3��6"   .+�5      �� $��10, 10, 10, 0q�6   Label66   �� 5      $	��300��6   $��10q�6%   $��Stretch=�61   ��5      �� *Label+ �� UpdateSourceTrigger$ PropertyChanged=�6T   5       �� 5!   
   $��1��6   $��3��6"   .+�5"      �� $��10, 10, 10, 0q�6   Description6<   �� 5#      $	��300��6   $��10q�6%   $��Stretch=�61   ��5$      �� *Description+$ PropertyChanged=�6Z   5%      �� 5&   
   $��2��6   $��3��6"   .+�5'      �� $��10, 10, 10, 0q�6   	Balance68   �� 5(      $	��300��6   $��10q�6%   $��Stretch=�61   ��5)      �� *	Balance+$ PropertyChanged=�6V   5*      �� 5+   
   $��3��6   $��3��6"   .+�5,      �� $��10, 10, 10, 0q�6   
Currency69   �� 5-      -   5        $��Currency��5-      $	��300��6'   $��10q�66   $��Stretch=�6B    �� Text 6`   �� *
Currency+$ PropertyChanged=�.@�5.      �� UAH6!   �� 5/      USD6!   �� 50      EUR6!   51      52      �� 53   
   $��4��6   .+�54      �� $��10, 10, 10, 10q�6   $
��Wrap=�60   DBCategories (if list is empty you should add some categories first)6�   �� 55      $��1��6   $	��100��6(   $	��400��68    �� DisplayMemberPath$ CategoryDisplayName��56      ��55   H   �� *
Categories+ �� SelectedItem 56   ;   �� *CurrentCategory+57      58      �� 59   
   $��1��6   $��4��6'   $��Stretch=�64   6T   �� 5;   
   $��2��6   $��4��6)   $��1��66   ��6H   �� *CurrentCategory+6n   �� 5=   
   $��5��6   $��3��6"   $	��100��66   $��Bottom=�6C   $��Stretch=�6^   .+�5>      �� -   5        $��BDeleteWallet��5>      $��18(�6*   $	��200��69   $	��400��6H   $��10,10,10,10q�6W   ��6l   �� *CreateWalletCommand+.��6�   Create New Wallet6�   �� 5?      -   5        $��BBack��5?      $��18(�6"   $	��200��61   $	��400��6@   $��10,10,10,10q�6O   ��6d   �� *BackCommand+.��6�   Back6�   5@      5A      5B      