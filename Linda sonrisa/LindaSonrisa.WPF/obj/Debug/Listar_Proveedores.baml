   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GLindaSonrisa.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LindaSonrisa.WPFLindaSonrisa.WPF 5   	   )   #LindaSonrisa.WPF.Listar_Proveedores   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LindaSonrisa.WPF     5   	   S OMahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null\ XMahApps.Metro.IconPacks.Material, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   $��0q�5
   	   (   "MahApps.Metro.Controls.MetroWindow    	GlowBrush
  �   � � Title$ S.WI.P��5   	   $��597.999��6   $��1362.849��6)    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P    � WindowState$ 	Maximized=�6u   .��5      � -   5         �Name$ dgListaProveedores��5      .+�5�   
   �� $	��Top=�6   ���#58ACFA.+�5�      o� $
��Auto��6   $
��Auto��6    ���#58ACFA.@�5�      �� $	��110��6   $
��Auto��6$   $ ��img/logo_linda_sonrisa.png��62   m� 5�      $��_Inicio��6   ���#58ACFA   MenuItemStyle#��[  6A   m� 5�      $��	_Registro��6   ���#58ACFA#��[  6C   .@�5�      m� -   5         m�Name$ 
_Proveedor��5�      $��
_Proveedor��63   $
��Left=�6G   $	��140��6b   ��6n   Z� .@�5�      m� -   5        $ _RegistroProveedor��5�   #   $��_Registro Proveedores��6?   $
��Left=�6^   $	��140��6y   ��6�   Z� 6�   m� 5�      -   5        $ _ListarProveedores��5�   #   $��_Listar Proveedores��6?   $
��Left=�6\   $	��140��6w   ��6�   Z� 6�   5�      m� 5�      -   5        $ 	_Clientes��5�      $��	_Clientes��62   $
��Left=�6E   $	��140��6`   ��6l   Z� .@�5�      m� -   5        $ _RegistroClientes��5�   #   $��_Registro Clientes��6>   $
��Left=�6Z   $	��140��6u   ��6�   Z� 6�   m� 5�      -   5        $ _ListarClientes��5�   #   $��_Listar Clientes��6<   $
��Left=�6V   $	��140��6q   ��6}   Z� 6�   5�      m� 5�      -   5        $ 
_Servicios��5�      $��
_Servicios��63   $
��Left=�6G   $	��140��6b   ��6n   Z� .@�5�      m� -	   5        $ _RegistroServicios��5�   #   $��_Registro Servicios��6?   $
��Left=�6\   $	��140��6w   ��6�   Z� 6�   m� 5�      -
   5        $ _ListarServicios��5�   #   $��_Listar Servicios��6=   $
��Left=�6X   $	��140��6s   ��6   Z� 6�   5�      m� 5�      -   5        $ 
_Empleados��5�      $��
_Empleados��63   $
��Left=�6G   $	��140��6b   ��6n   Z� .@�5�      m� -   5        $ _RegistroEmpleados��5�   #   $��_Registro Empleados��6?   $
��Left=�6\   $	��140��6w   ��6�   Z� 6�   m� 5�      -   5        $ _ListarEmpleados��5�   #   $��_Listar Empleados��6=   $
��Left=�6X   $	��140��6s   ��6   Z� 6�   5�      m� 5�      -   5        $ 
_Productos��5�      $��
_Productos��63   $
��Left=�6G   $	��140��6b   ��6n   Z� .@�5�      m� -   5        $ _RegistroProductos��5�   #   $��_Registro Productos��6?   $
��Left=�6\   $	��140��6w   ��6�   Z� 6�   m� 5�      -   5        $ _ListarProductos��5�   #   $��_Listar Productos��6=   $
��Left=�6X   $	��140��6s   ��6   Z� 6�   5�      5�      m� 5�      $��_Reserva de Hora��6   ���#58ACFA#��[  6J   .@�5�      m� -   5        $ About��5�      $��About��6.   $
��Left=�6=   $	��140��6X   5�      m� 5�      $��_Orden Pedido��6   ���#58ACFA#��[  6G   m� 5�      $��_Boleta Servicio��6   ���#58ACFA#��[  6J   m� 5�      -   5        $��_Informes y Estadísticas��5�      ���#58ACFA#��[  6R   6y   5�      5�      �� 5�   
   -   5         ��Name$ 	btn_salir��5�      $
��Left=�6%   $��1222,-2,0,0q�6@   $	��Top=�6U   $��20,20,20,20q�6n    J� RenderTransformOrigin$ 0.261,0.593&�6�     MetroCircleButtonStyle#���  6�   ���	#FF236CB6���	#FF295CE4	 � ToolTip$	 Cerrar Sesión��6   .��5�      .  (MahApps.Metro.IconPacks.PackIconMaterial  E	 AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null� 	 �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]
   Kind$
 Power=�6*   
�������68   5�      �� 5�   
   -   5         ��Name$ 	lblTitulo��5�      $��Listado de Proveedores��6#   $
��Left=�6D   $��
570,72,0,0q�6_   $	��Top=�6s   $��24(�6�   $��Myriad Pro Light)�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5�   
   -   5          Name$ dgProveedores��5�         AutoGenerateColumns .     CanUserAddRows .  $
��Left=�6]   $��122,203,0,0q�6x   $	��Top=�6�   $
��1156��6�   $��1q�6�      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre del proveedor��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6u   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   ��  �� Path$ Nombre�   HeaderStyle 5�      �� 5�       �� 
TargetType=	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6    .�5�      ��  �� Property � �� �� Value �#58ACFA6;   �� 5�       � ��
 �����6;   5�      5�        5�      $	 Rut��6%    . $ * 6d    6E   �� $ RutDv� 5�      �� 5�      " 	 6    .�5�      ��  � �� �#58ACFA6;   �� 5�       � ��
 �����6;   5�      5�        5�      $ Rubro��6%    . $ * 6f    6G   �� $ Rubro� 5�      �� 5�      " 	 6    .�5�      ��  � �� �#58ACFA6;   �� 5�       � ��
 �����6;   5�      5�        5�      $ Contacto telefonico��6%    . $ * 6�    6U   �� $ Telefono� �� StringFormat$ 0�� 5�      �� 5�      " 	 6    .�5�      ��  � �� �#58ACFA6;   �� 5�       � ��
 �����6;   5�      5�        5�      $ Correo electronico��6%    . $ * 6t    6T   �� $ Correo� 5�      �� 5�      " 	 6    .�5�      ��  � �� �#58ACFA6;   �� 5�       � ��
 �����6;   5�      5�        5�      $ Nombre de la comuna��6%    . $ * 6�    6U   �� $ NombreComuna�$ 0�� 5�      �� 5�      " 	 6    .�5�      ��  � �� �#58ACFA6;   �� 5�       � ��
 �����6;   5�      5�      4
  .System.Windows.Controls.DataGridTemplateColumn
  5�       5�      �� 5�      " 	 6    .�5�      ��  � �� �#58ACFA6;   �� 5�       � ��
 �����6;   5�       
  CellTemplate 5�      �� 5�      .R�5�      �� -   5        
�������.��5�   "     $
 Pencil=�6>   
���   �6L   5�      5      5     
  5      5     �� 5     " 	 6    .�5     ��  � �� �#58ACFA6;   �� 5      � ��
 �����6;   5	      5     �� 5     .R�5     �� -   5        
�������.��5  "     $
 Delete=�6>   
���  ��6L   5     5     5     5     �� 5  
   -   5         ��Name$ cboTipoFiltro��5     $
��Left=�6*   $��185,141,0,0q�6E   $	��Top=�6Z   $	��224��6r   $��29��6~   6�   �� 5  
   -   5        $ lblTipoProducto��5     $��Filtro��6)   $
��Left=�6:   $��185,110,0,0q�6U   $	��Top=�6j   $	��126��6�   �� 5  
   -   5        $ 
btnFiltrar��5     $��Filtrar��6%   $
��Left=�67   $��693,141,0,0q�6R   $	��Top=�6g   $	��111��6   $��29��6�   ���#58ACFA���	#FF0ECDEC6�   �� 5  
   -   5        $ 	cboFiltro��5     $
��Left=�6&   $��453,141,0,0q�6A   $	��Top=�6V   $	��224��6n   $��29��6z   �� 5  
   -   5        $ labelBuscarPor��5     $��Filtro��6(   $
��Left=�69   $��453,110,0,0q�6T   $	��Top=�6i   $	��126��6�   �� 5  
   -   5        $ btn_ver_todos��5     $��	VER TODOS��6(   $
��Left=�6<   $��836,141,0,0q�6W   $	��Top=�6l   $	��111��6�   $��29��6�   ���#58ACFA���	#FF0ECDEC6�   5     5     