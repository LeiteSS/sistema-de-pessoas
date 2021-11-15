package br.com.unip.people;

import android.os.Bundle;
import android.webkit.WebView;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        WebView webView = findViewById(R.id.webview);

        String html = "<html><body><h1>Cadastrar e Consultar Pessoas</h1><h3>Pagina escrita em uma string para ser renderizada no WebView</h3></body></html>";
        webView.loadData(html, "text/html", "UTF-8");
        ///webView.loadUrl("www.google.com.br");
    }
}
