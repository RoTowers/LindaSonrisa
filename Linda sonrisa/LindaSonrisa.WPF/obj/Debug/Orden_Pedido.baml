   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GLindaSonrisa.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LindaSonrisa.WPFLindaSonrisa.WPF 5   	   #   LindaSonrisa.WPF.Orden_Pedido   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LindaSonrisa.WPF     5   	   S OMahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null\ XMahApps.Metro.IconPacks.Material, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	     � Title$  S.WI.P��5
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
��Left=�6%   $��1222,-2,0,0q�6@   $	��Top=�6U   $��20,20,20,20q�6n    J� RenderTransformOrigin$ 0.261,0.593&�6�     MetroCircleButtonStyle#���  6�   ���	#FF236CB6���	#FF295CE4.��5      .  (MahApps.Metro.IconPacks.PackIconMaterial  E	 AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null� 	 �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ Power=�6*   
�������68   5       �� 5"   
   -   5         ��Name$ cboFamiliaProductos��5"      $
��Left=�60   $��206,177,0,0q�6K   $	��Top=�6`   $	��191��6x   $��41��6�   �� 5#   
   -   5        	 ��Name$	 lblFamiliaProductos��5#      $��Familia de Productos:��6-   $
��Left=�6M   $��206,146,0,0q�6h   $	��Top=�6}   �� 5$   
   -   5        $ cboTipoProducto��5$      $
��Left=�6,   $��569,177,0,0q�6G   $	��Top=�6\   $	��191��6t   $��41��6�   �� 5%   
   -   5        $	 lblTipoProducto��5%      $��Tipo de Producto:��6)   $
��Left=�6E   $��569,146,0,0q�6`   $	��Top=�6u   �� 5&   
   -	   5        $ cboProducto��5&      $
��Left=�6(   $��921,177,0,0q�6C   $	��Top=�6X   $	��191��6p   $��41��6|   �� 5'   
   -
   5        $	 lblProducto��5'      $��	Producto:��6%   $
��Left=�69   $��921,146,0,0q�6T   $	��Top=�6i   �� 5(   
   -   5        $ cboProveedor��5(      $
��Left=�6)   $��206,292,0,0q�6D   $	��Top=�6Y   $	��191��6q   $��41��6}   �� 5)   
   -   5        $	 lblProveedor��5)      $��
Proveedor:��6&   $
��Left=�6;   $��206,261,0,0q�6V   $	��Top=�6k   �� 5*   
   -   5        
 ��Name$
 txtCantidad��5*      $
��Left=�6'   $��41��6B   $��658,292,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $��58��6�   6�   �� 5+   
   -   5        $	 lblCantidad��5+      $��	Cantidad:��6%   $
��Left=�69   $��569,292,0,0q�6T   $	��Top=�6i   �� 5,   
   -   5        $ 
btnAgregar��5,      $��Agregar��6%   $
��Left=�67   $��921,282,0,0q�6R   $	��Top=�6g   $	��132��6   $��47��6�   ���#58ACFA���	#FF0ECDEC6�   �� 5-   
   -   5        $ btnPedir��5-      $��Pedir��6#   $
��Left=�63   $��503,505,0,0q�6N   $	��Top=�6c   $	��132��6{   $��47��6�   ���#58ACFA���	#FF0ECDEC6�   �� 5.   
   -   5        $ btnModificar��5.      $��	Modificar��6'   $
��Left=�6;   $��725,505,0,0q�6V   $	��Top=�6k   $	��132��6�   $��47��6�   ���#58ACFA���	#FF0ECDEC6�   &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ 	dgPedidos��5/      $
��Left=�6&   $��448,374,0,0q�6A   $	��Top=�6V   $��0��6�      AutoGenerateColumns .  $	��500��6�   $	��100��6�      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .  $��1q�6@  ��6n   ��  �� Path$ Albums� J� Effect 50      3  -System.Windows.Media.Effects.DropShadowEffect  51         Opacity$	 0.2Q�6#      ShadowDepth$ 10Q�61      	Direction$	 250Q�6B      
BlurRadius$ 60Q�6R      Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Familia��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
Genre.Name+6U     55      $
 Tipo��6%   $
 auto 6R    63   �� *
Genre.Name+6R     56      $ Producto��6%   $
 auto 6V    67   �� *
Genre.Name+6V     57      $ 	Proveedor��6%   $
 auto 6W    68   �� *
Genre.Name+6W   59      �� 5:   
   -   5        $	 	lblTitulo��5:      $��Orden de Pedido��6#   $
��Left=�6=   $��
610,74,0,0q�6X   $	��Top=�6l   $��24(�6�   $
��Bold"�6�   $��Myriad Pro Light)�6�   5;      5<      