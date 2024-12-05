import 'package:flutter/material.dart';

class ScanAnimalPage extends StatefulWidget {
  const ScanAnimalPage({super.key});

  @override
  State<ScanAnimalPage> createState() => _ScanAnimalPageState();
}

class _ScanAnimalPageState extends State<ScanAnimalPage> {
  @override
  Widget build(BuildContext context) {
    // Access the color scheme from the theme
    final colorScheme = Theme.of(context).colorScheme;

    return Scaffold(
      appBar: AppBar(
        title: const Center(child: Text("Leeuw")),
        backgroundColor: colorScheme.primary,
        foregroundColor: colorScheme.onPrimary,
        shadowColor: Colors.black,
        elevation: 2,
      ),
      body: Container(
        padding: const EdgeInsets.all(5.0),
        child: const Text("Here comes unity view later"),
      ),
    );
  }
}
