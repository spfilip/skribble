package com.example.filip.lab_intents;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    TextView txtView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }


    public void mainbtn1Click(View view) {
        Intent explicitIntent = new Intent(this, ExplicitActivity.class);
        startActivityForResult(explicitIntent, 0);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        txtView = (TextView) findViewById(R.id.textView);
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode == RESULT_OK && requestCode == 0) {
            String str = data.getStringExtra("key");
            txtView.setText(str);
        }
        if (resultCode == RESULT_OK && requestCode == 1) {

            Uri pictureUri = data.getData();
            Intent pictureIntent;
            pictureIntent = new Intent(Intent.ACTION_VIEW, pictureUri);

            if (pictureIntent.resolveActivity(getPackageManager()) != null)
                startActivity(pictureIntent);
        }
    }

    public void mainbtn3Click(View view) {
        Intent intent = new Intent(Intent.ACTION_SEND);
        intent.setType("text/plain");
        intent.putExtra(Intent.EXTRA_TITLE, "MPiP Send Title");
        intent.putExtra(Intent.EXTRA_TEXT, "Content send from MainActivity");
        startActivity(intent.createChooser(intent, "Share"));
    }

    public void mainbtn2Click(View view) {
        Intent intent = new Intent();
        intent.setAction("mk.ukim.finki.mpip.IMPLICIT_ACTION");
        startActivity(intent);
    }

    public void mainbtn4Click(View view) {
        Intent intent = new Intent();
        intent.setType("image/*");
        intent.setAction(Intent.ACTION_GET_CONTENT);
        startActivityForResult(intent, 1);
    }


}
