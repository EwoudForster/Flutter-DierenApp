import 'package:flutter/material.dart';

class ScoreboardPage extends StatelessWidget {
  const ScoreboardPage({super.key});

  @override
  Widget build(BuildContext context) {
    // Access the color scheme from the theme
    final colorScheme = Theme.of(context).colorScheme;

    return Scaffold(
      appBar: AppBar(
        title: const Center(child: Text("Scorebord")),
        backgroundColor: colorScheme.primary,
        foregroundColor: colorScheme.onPrimary,
        shadowColor: Colors.black,
        elevation: 2,
      ),
      body: Container(
        padding: const EdgeInsets.all(5.0),
        child: const Text("Coming soon."),
      ),
    );
  }
}
