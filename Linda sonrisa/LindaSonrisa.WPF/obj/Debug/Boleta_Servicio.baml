   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GLindaSonrisa.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LindaSonrisa.WPFLindaSonrisa.WPF 5   	   &    LindaSonrisa.WPF.Boleta_Servicio   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LindaSonrisa.WPF     5   	   S OMahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null\ XMahApps.Metro.IconPacks.Material, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	     � Title$  S.WI.P��5
   	   $��597.999��6   $��1506.849��6)    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P    � WindowState$ 	Maximized=�6u   .��5      � .+�5   
   �� $	��Top=�6   ���#58ACFA.+�5      o� $
��Auto��6   $
��Auto��6    ���#58ACFA.@�5      �� $	��110��6   $
��Auto��6$   $!��img/logo linda sonrrisa.png��62   m� 5      $��_Inicio��6   ���#58ACFA   MenuItemStyle#��[  6A   .@�5      m� -   5         m�Name$ AppExit��5      $��E_xit��60   $
��Left=�6?   $	��140��6Z   #��[  6f   5      m� 5      $��	_Registro��6   ���#58ACFA#��[  6C   .@�5      m� -   5        $ Options��5      $��_Options��60   $
��Left=�6B   $	��140��6]   ��6i   Z� 5      m� 5      $��_Reserva de Hora��6   ���#58ACFA#��[  6J   .@�5      m� -   5        $ About��5      $��About��6.   $
��Left=�6=   $	��140��6X   5      m� 5      $��_Orden Pedido��6   ���#58ACFA#��[  6G   m� 5      $��_Boleta Servicio��6   ���#58ACFA#��[  6J   m� 5      $��_Informes y Estadísticas��6   ���#58ACFA#��[  6R   5      5      �� 5   
   -   5         ��Name$ 	btn_salir��5      $
��Left=�6%   $��1222,-2,0,0q�6@   $	��Top=�6U   $��20,20,20,20q�6n    J� RenderTransformOrigin$ 0.261,0.593&�6�     MetroCircleButtonStyle#���  6�   ���	#FF236CB6���	#FF295CE4 � ToolTip$ Cerrar Sesión��6   .��5      .  (MahApps.Metro.IconPacks.PackIconMaterial  E	 AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null� 	 �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ Power=�6*   
�������68   5       �� 5"   
   -   5        	 ��Name$	 
lblFiltrar��5"      $��Filtrar por:��6$   $
��Left=�6;   $��307,187,0,0q�6V   $	��Top=�6k   �� 5#   
   -   5        
 ��Name$
 
cboFiltrar��5#      $
��Left=�6'   $��307,218,0,0q�6B   $	��Top=�6W   $	��191��6o   $��41��6{   �� 5$   
   -   5         ��Name$ 
txtFiltrar��5$      $
��Left=�6&   $��41��6A   $��598,218,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��191��6�   �� 5%   
   -   5        $ 
btnFiltrar��5%      $��Filtrar��6%   $
��Left=�67   $��886,218,0,0q�6R   $	��Top=�6g   $	��140��6   $��41��6�   ���#58ACFA���	#FF0ECDEC6�   &   System.Windows.Controls.DataGrid  5&   
   -	   5          Name$ 	dgBoletas��5&      $
��Left=�6&   $��307,318,0,0q�6A   $	��Top=�6V   $��0��6�      AutoGenerateColumns .  $	��719��6�   $	��130��6�      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .  $��1q�6@  ��6n   ��  �� Path$ Albums� J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         Opacity$	 0.2Q�6#      ShadowDepth$ 10Q�61      	Direction$	 250Q�6B      
BlurRadius$ 60Q�6R      Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Rut/Pasaporte��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
Genre.Name+6[     5,      $ Servicio��6%   $
 auto 6V    67   �� *
Genre.Name+6V     5-      $ Fecha��6%   $
 auto 6S    64   �� *
Genre.Name+6S     5.      $
 Hora��6%   $
 auto 6R    63   �� *
Genre.Name+6R     5/      $  ��6%   $
 auto 6N    6/   �� *
Genre.Name+6N   51      �� 52   
   -
   5        $	 	lblTitulo��52      $��Boleta Servicio��6#   $
��Left=�6=   $��
626,88,0,0q�6X   $	��Top=�6l   $��24(�6�   $
��Bold"�6�   $��Myriad Pro Light)�6�   53      54      