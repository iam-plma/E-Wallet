   M S B A M L   `   `   `  ����E  AEWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EWalletWPF.AuthenticationEWalletWPF.Authentication  5      *    $EWalletWPF.Authentication.SignUpView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:EWalletWPF.Authentication     5      .��5      � $��1��6   $��Center=�6   $��Center=�63     � RowDefinitions  5	   
   �� 5
      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   .+�5   
   �� $��2��6   .+�5      �� $��10, 10, 10, 0q�6   Login67   �� 5      $	��300��6   $��10q�6"   $��Stretch=�6.   ��6L   �� *Login+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5   
   $��1��6   $��0��6"   .+�5      �� $��10, 10, 10, 0q�6   
First Name6;   �� 5      $
��Auto��6   $��10q�6#   $��Stretch=�6/   ��6M   �� *	FirstName+$ PropertyChanged=�6�   5      �� 5   
   $��1��6   $��1��6"   .+�5      �� $��10, 10, 10, 0q�6   	Last Name6:   �� 5      $
��Auto��6   $��10q�6#   $��Stretch=�6/   ��6M   �� *
LastName+$ PropertyChanged=�6�   5       �� 5!   
   $��2��6   $��2��6"   .+�5"      �� $��10, 10, 10, 0q�6   Email (apple@vovan.com)6H   �� 5#      -   5        $	��300��5#      $��10q�6"   $��Stretch=�6.   ��6L   �� *Email+$ PropertyChanged=�6�   5$      �� 5%   
   $��3��6   $��0��6"   $��2��62   .+�5&      �� $��10, 10, 10, 0q�6   Password (min 8 symbols)6I   G� 5'      -   5        $��
TbPassword��5'      $	��300��6,   $��10q�68   $��Stretch=�6D   6�   5(      �� 5)   
   $��4��6   $��0��6"   $��2��62   .+�5*      �� $��10, 10, 10, 0q�6   Repeat Password6@   G� 5+      -   5        $��TbPasswordRepeat��5+      $	��300��62   $��10q�6>   $��Stretch=�6J   6�   5,      �� 5-   
   -   5        $��BSignIn��5-      $��0��6    $��10,10,10,10q�60   $��5��6g   ��6E   �� *SignUpCommand+.��6t   	Sign Up6}   �� 5.   
   $��1��6   $��10,10,10,10q�6!   $��5��6X   $��2��6e   ��66   �� *SignInCommand+.��6y   Go to Sign In6�   5/      50      