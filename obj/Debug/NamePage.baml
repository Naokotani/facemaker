   M S B A M L   `   `   `  ����M  IM01_First_WPF_Proj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:M01_First_WPF_ProjM01_First_WPF_Proj  5      !    M01_First_WPF_Proj.NamePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:M01_First_WPF_Proj     5        N� Title$  NamePage��5	      .��5
      � .+�5   
   �� $��Stretch=�6   $��Stretch=�62   
���   ���5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ White��6#    � Offset$ 1Q�61   5      5      � 5   
   $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��167* �6#   �� 5      $
��178* �6#   .+�5!      �� $��0��6   $��Whats you name?��6%   $��20(�5"      ���	#FF39AD11$��Center=�6=   $��0,0,0,20q�6Z   $��1��6l   $	��158��6|   ��5#      �� 5$      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5%      � $ Black��6'   � 5&      $ 	#FFD86262��6'   $ 1Q�69   5'      5)      �� 5*      $��1��6   $��0��6%   $��First Name:��65   ���	#FFFF25BB$��	0,0,10,10q�6_   �� 5+      $��2��6   $��0��6%   $��
Last Name:��65   $��	0,0,10,10q�6G   ���	#FFFF25BB6Z   �� 5,      $��3��6   $��0��6%   $��Address:��65   $��0,2,10,8q�6E   ���	#FFFF25BB��5-      �� 5.      50      �� 51      -   5        $��4��51      $
��Next��6"   $��0,10,223,20q�61   ���	#FF77C6D0���	#FFA43E3E$��1��52   V   �� 53      -   5         ��Name$ 	fNameText��53      $��1��6)   $��Center=�69   $��19��6V   $��1��6b    �� TextWrapping$
 Wrap=�6o   $��Center=�6�   $	��334��6�   �� 54      -   5        $ 	lNameText��54      $��1��6)   $��Center=�69   $��21��6V   $��2��6b   $
 Wrap=�6o   $��Center=�6�   $	��334��6�   �� 55      -   5        $ addressText��55      $��1��6+   $��Center=�6;   $��21��6X   $��3��6d   $
 Wrap=�6q   $��Center=�6�   $	��334��6�   56      57      58      