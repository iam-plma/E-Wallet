   M S B A M L   `   `   `  ����E  AEWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EWalletWPF.AuthenticationEWalletWPF.Authentication  5      *    $EWalletWPF.Authentication.SignInView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:EWalletWPF.Authentication     5      {�5      �� *	IsEnabled+.��5	      � $��1��6   $��Center=�6   $��Center=�63     � RowDefinitions  5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $��2��6   .+�5      �� $��10, 10, 10, 0q�6   Login66   �� 5      -   5        $��TbLogin��5      $	��300��6%   $��10q�61   $��Stretch=�6=   ��6[   �� *Login+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5   
   $��1��6   $��0��6"   $��2��62   .+�5      �� $��10, 10, 10, 0q�6   
Password69   G� 5      -   5        $��
TbPassword��5      $	��300��6,   $��10q�68   $��Stretch=�6D   6�   5      �� 5   
   -   5        $��BSignIn��5      $��0��6    $��10,10,10,10q�60   $��2��6g   ��6E   �� *SignInCommand+.��6t   	Sign In6}   �� 5   
   -   5        $��BClose��5      $��2��6   $��1��6,   $��10q�6<   ��6H   �� *CloseCommand+.��6i   Quit6o   �� 5   
   $��0��6   $��10,10,10,10q�6!   $��3��6X   $��2��6e   ��66   �� *SignUpCommand+.��6y   Not registered? Sign Up Now6�   5      5       