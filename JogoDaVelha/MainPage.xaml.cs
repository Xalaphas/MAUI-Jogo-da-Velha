namespace JogoDaVelha;

public partial class MainPage : ContentPage
{
	private string vez = "X";
	private string[,] tabuleiro = new string[3, 3];
	private Button[,] botoes = new Button[3, 3];

	public MainPage()
	{
		InitializeComponent();
		InicializarBotoes();
	}

	private void InicializarBotoes(){
		botoes[0, 0] = btn10;
		botoes[0, 1] = btn11;
		botoes[0, 2] = btn12;
		botoes[1, 0] = btn20;
		botoes[1, 1] = btn21;
		botoes[1, 2] = btn22;
		botoes[2, 0] = btn30;
		botoes[2, 1] = btn31;
		botoes[2, 2] = btn32;

		Zerar();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Button button = (Button)sender;
		int linha = int.Parse(button.ClassId[0].ToString());
		int coluna = int.Parse(button.ClassId[1].ToString());

		button.Text = vez;
		button.IsEnabled = false;
		tabuleiro[linha, coluna] = vez;

		if (Ganhar())
		{
			DisplayAlert("Vitória", $"Jogador {vez} venceu!", "OK");
			Zerar();
		} else if (Empate()) {
			DisplayAlert("Deu Velha!", "Ninguém venceu", "OK");
			Zerar();
		} else {
			vez = vez == "X" ? "O" : "X";
		}

    }

	 private void Zerar()
        {
            vez = "X";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = string.Empty;
                    botoes[i, j].Text = string.Empty;
                    botoes[i, j].IsEnabled = true;
                    botoes[i, j].ClassId = $"{i}{j}"; // Identificador para localização no tabuleiro
                }
            }
        }



	private bool Ganhar() {
		for (int i = 0; i < 3; i++)
		{
			if ((tabuleiro[i, 0] == vez && tabuleiro[i, 1] == vez && tabuleiro[i, 2] == vez) || // Linha
                    (tabuleiro[0, i] == vez && tabuleiro[1, i] == vez && tabuleiro[2, i] == vez))
			{
				return true;
			}
		}

		if ((tabuleiro[0, 0] == vez && tabuleiro[1, 1] == vez && tabuleiro[2, 2] == vez) || // Diagonal principal
                (tabuleiro[0, 2] == vez && tabuleiro[1, 1] == vez && tabuleiro[2, 0] == vez))   // Diagonal secundária
            {
                return true;
            }
		return false;
	}

	private bool Empate() {
		foreach (string valor in tabuleiro)
		{
			if (string.IsNullOrEmpty(valor))
			{
				return false;
			}
		}
		return true;
	}
}