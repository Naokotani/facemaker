   M S B A M L   `   `   `  ����M  IM01_First_WPF_Proj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:M01_First_WPF_ProjM01_First_WPF_Proj  5   	   #    M01_First_WPF_Proj.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:M01_First_WPF_Proj     5   	     � Title$  
MainWindow��5   	   $
��1050��6   $
��1250��6*   .��5	      � .+�5
   
   ]� $��	0,0,0,262q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ White��6#    � Offset$ 1Q�61   5       J� OpacityMask 5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   � 5      $ White��6#   $ 1Q�61   5      .+�5      o� -   5         o�Name$
 menu��5       o� 
IsMainMenu . $��20��63   $	��Top=�6?   .@�5      m� $��MainMenu��6   .@�5      m� $��_Hair��6   .@�5      m� $��	_Hair One��6#    m� CommandParameter$ 1��6O   	 m� InputGestureText$	 F1��6d   
 m� Command
 66   �� *hair+6d   m� 5      $��	_Hair Two��6#   $ 2��6O   $	 F2��6d   
 66   �� *hair+6d   m� 5      $��_Hair Three��6#   $ 3��6Q   $	 F3��6f   
 68   �� *hair+6f   5      m� 5      $��_Eyes��6   .@�5      m� $��	_Eyes One��6#   $ 1��6O   $	 F4��6d   
 66   �� *eyes+6d   m� 5       $��
_Eyes Two ��6#   $ 2��6P   $	 F5��6e   
 67   �� *eyes+6e   m� 5!      $��_Eyes Three��6#   $ 3��6Q   $	 F6��6f   
 68   �� *eyes+6f   5"      m� 5#      $��_Nose��6   .@�5$      m� $��	_Nose One��6#   $ 1��6O   $	 F7��6d   
 66   �� *nose+6d   m� 5%      $��	_Nose Two��6#   $ 2��6O   $	 F8��6d   
 66   �� *nose+6d   m� 5&      $��_Nose Three��6#   $ 3��6Q   $	 F9��6f   
 68   �� *nose+6f   5'      m� 5(      $��_Mouth��6   .@�5)      m� $��
_Mouth One��6#   $ 1��6Q   $		 F10��6f   
 67   �� *mouth+6f   m� 5*      $��
_Mouth Two��6#   $ 2��6Q   $		 F11��6f   
 67   �� *mouth+6f   m� 5+      $��_Mouth Three��6#   $ 3��6S   $		 F12��6h   
 69   �� *mouth+6h   5,      5-      m� 5.      $��_Help��6   .@�5/   
   m� -   5        $��_Online Documentation��5/      62   50      51      52       � 53   
   -   5          �Name$ 	MainFrame��53        � NavigationUIVisibility$ Hidden=�6#   54      55      