   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GLindaSonrisa.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LindaSonrisa.WPFLindaSonrisa.WPF 5   	   #   LindaSonrisa.WPF.Reserva_Hora   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LindaSonrisa.WPF     5   	   S OMahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null\ XMahApps.Metro.IconPacks.Material, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	     � Title$  S.WI.P��5
   	   $��647.375��6   $��1506.849��6)    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P    � WindowState$ 	Maximized=�6u   .��5      � .+�5   
   �� $	��Top=�6   ���#58ACFA.+�5      o� $
��Auto��6   $
��Auto��6    ���#58ACFA.@�5      �� $	��110��6   $
��Auto��6$   $!��img/logo linda sonrrisa.png��62   m� 5      $��_Inicio��6   ���#58ACFA   MenuItemStyle#��[  6A   .@�5      m� -   5         m�Name$ AppExit��5      $��E_xit��60   $
��Left=�6?   $	��140��6Z   #��[  6f   5      m� 5      $��	_Registro��6   ���#58ACFA#��[  6C   .@�5      m� -   5        $ Options��5      $��_Options��60   $
��Left=�6B   $	��140��6]   ��6i   Z� 5      m� 5      $��_Reserva de Hora��6   ���#58ACFA#��[  6J   .@�5      m� -   5        $ About��5      $��About��6.   $
��Left=�6=   $	��140��6X   5      m� 5      $��_Orden Pedido��6   ���#58ACFA#��[  6G   m� 5      $��_Boleta Servicio��6   ���#58ACFA#��[  6J   m� 5      $��_Informes y Estadísticas��6   ���#58ACFA#��[  6R   5      5      �� 5   
   -   5         ��Name$ 	btn_salir��5      $
��Left=�6%   $��1222,-2,0,0q�6@   $	��Top=�6U   $��20,20,20,20q�6n    J� RenderTransformOrigin$ 0.261,0.593&�6�     MetroCircleButtonStyle#���  6�   ���	#FF236CB6���	#FF295CE4 � ToolTip$ Cerrar Sesión��6   .��5       .  (MahApps.Metro.IconPacks.PackIconMaterial  E	 AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null� 	 �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ Power=�6*   
�������68   5!      �� 5#   
   -   5        	 ��Name$	 lblNombreUsuario��5#      $�� ��6*   $
��Left=�65   $��1157,13,0,0q�6P   $	��Top=�6e   $	��101��6}   �� 5$   
   -   5        $	 	lblNombre��5$      $�� ��6#   $
��Left=�6.   $��
302,65,0,0q�6I   $	��Top=�6]   �� 5%   
   -   5        $	 lblDescripcion��5%      $�� ��6(   $
��Left=�63   $��417,144,0,0q�6N   $	��Top=�6c   �� 5&   
   -   5        $	 
lblMensaje��5&      $�� ��6$   $
��Left=�6/   $��492,144,0,0q�6J   $	��Top=�6_   �� 5(   
   -	   5        
 ��Name$
 cboServicios��5(      $
��Left=�6)   $��212,205,0,0q�6D   $	��Top=�6Y   $	��191��6q   $��41��6}   �� 5)   
   -
   5        $	 lblServicios��5)      $��
Servicios:��6&   $
��Left=�6;   $��212,174,0,0q�6V   $	��Top=�6k   �� 5*   
   -   5        $
 cboOdontologo��5*      $
��Left=�6*   $��575,205,0,0q�6E   $	��Top=�6Z   $	��191��6r   $��41��6~   �� 5+   
   -   5        $	 lblOdontologo��5+      $��Odontólogo:��6'   $
��Left=�6=   $��575,174,0,0q�6X   $	��Top=�6m   (  "System.Windows.Controls.DatePicker  5,   
   $
��Left=�6   $��969,205,0,0q�60   $	��Top=�6E   $��41��6]   $	��191��6i   �� 5-   
   -   5        $	 lblFecha��5-      $��Fecha:��6"   $
��Left=�63   $��969,179,0,0q�6N   $	��Top=�6c   �� 5.   
   -   5         ��Name$ lbxHora��5.      $
��Left=�6#   $	��100��6>   $��969,332,0,0q�6K   $	��Top=�6`   $	��191��6x   $��1q�6�   �� 5/   
   -   5        $	 lblHora��5/      $��Hora:��6!   $
��Left=�61   $��969,306,0,0q�6L   $	��Top=�6a   �� 50   
   -   5        $ lbxReservas��50      $
��Left=�6'   $	��137��6B   $��212,332,0,0q�6O   $	��Top=�6d   $	��349��6|   $��1q�6�   �� 51   
   -   5        $ 
btnAgregar��51      $��Agregar��6%   $
��Left=�67   $��212,496,0,0q�6R   $	��Top=�6g   $	��100��6   $��37��6�   ���#58ACFA���	#FF0ECDEC6�   �� 52   
   -   5        $ 	btnQuitar��52      $��Quitar��6$   $
��Left=�65   $��343,496,0,0q�6P   $	��Top=�6e   $	��100��6}   $��37��6�   ���#58ACFA���	#FF0ECDEC6�   �� 53   
   -   5        $ btnReservar��53      $��Reservar��6&   $
��Left=�69   $��648,539,0,0q�6T   $	��Top=�6i   $	��171��6�   $��45��6�   ���#58ACFA���	#FF0ECDEC6�   �� 54   
   -   5        $	 	lblTitulo��54      $��Reserva de Hora��6#   $
��Left=�6=   $��
677,87,0,0q�6X   $	��Top=�6l   $��24(�6�   $��Myriad Pro Light)�6�   $
��Bold"�6�   57      58      