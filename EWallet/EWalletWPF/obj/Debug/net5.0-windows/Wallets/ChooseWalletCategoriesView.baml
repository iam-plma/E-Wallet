   M S B A M L   `   `   `  ����E  AEWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EWalletWPF.WalletsEWalletWPF.Wallets  5      3    -EWalletWPF.Wallets.ChooseWalletCategoriesView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EWalletWPF.Wallets     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   �� $��0��6   .+�5      �� $��10, 10, 10, 0q�6   Label66   �� 5       �� 
IsReadOnly$
 True��6   $	��300��6(   $��10q�67   $��Stretch=�6C   ��5      �� *Label+ �� UpdateSourceTrigger$ PropertyChanged=�6T   5      �� 5   
   $��1��6   .+�5      �� $��10, 10, 10, 0q�6   Description6<   �� 5      $
 True��6   $	��300��6(   $��10q�67   $��Stretch=�6C   ��5      �� *Description+$ PropertyChanged=�6Z   5      �� 5   
   $��3��6   $��Bottom=�6"   .+�5      �� -   5        $��BAddCategory��5      $��18(�6)   $	��200��68   $	��400��6G   $��10,10,10,10q�6V   ��6k   �� *AddCategoryCommand+.��6�   Add Category6�   5      5      5      