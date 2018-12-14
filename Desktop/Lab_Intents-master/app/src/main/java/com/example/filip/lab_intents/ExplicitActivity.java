package com.example.filip.lab_intents;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.EditText;

public class ExplicitActivity extends AppCompatActivity {

    EditText editText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_explicit);
    }

    public void explicitbtnOK(View view) {
        editText = (EditText) findViewById(R.id.editText);

        if (editText.getText().toString()!="") {
            Intent intent = new Intent();
            intent.putExtra("key",editText.getText().toString());
            setResult(RESULT_OK, intent);
            finish();
        }
    }

    public void explicitbtnCancel(View view) {
        setResult(RESULT_CANCELED);
        finish();
    }
}
