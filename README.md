# clase_ado

query para obtner los datos de mysql: 
*_SELECT User, Host, authentication_string FROM mysql.user;_* 

instalar el nuggets: 
*_MySql.Data_* 

Datos de los connectionString:  
"Server=localhost;Database=nombre_de_tu_bd;User ID=nombre_de_usuario;Password=contraseña;SslMode=none;";  
Server-> solo localhost sin puerto ni nada.  
Database-> nombre de la base de datos.  
se obtiene con la query de arriba:  
User ID-> es el usuario de mysql, por lo gral es *_root_*  
Password-> si tuviera, caso contrario se deja vacio *_Password=;_* 





