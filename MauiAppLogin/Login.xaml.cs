using WinRT;

namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e )
	{
		try
		{
			List<DadosUsuario> lista_usuarios = new List<DadosUsuario>() // Cria��o de lista de usu�rios est�tica (para fins did�ticos)
			{
				new DadosUsuario()
				{
					Usuario = "jose",
					Senha = "123"
				},
				new DadosUsuario()
				{
					Usuario = "maria",
					Senha ="321"
				}
			};

			DadosUsuario dados_digitados = new DadosUsuario() // Captura de dados digitados pelo poss�vel usu�rio
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			// LINQ
			if(lista_usuarios.Any(
				// Para cada item da lista ser� procurado um valor para usu�rio e senha,
				// encontrado um usu�rio E a senha respectiva
				i => (dados_digitados.Usuario == i.Usuario && 
					 dados_digitados.Senha == i.Senha)) ) 
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();

			} else
			{
				throw new Exception("Usu�rio ou senha incorretos.");
			}


		} catch(Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
	}

}