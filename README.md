# Practica_2

## Descripción General

Este proyecto consiste en una aplicación de consola desarrollada en C# que permite realizar operaciones matemáticas sobre una lista de números utilizando genéricos, delegados y control de excepciones.

La aplicación permite al usuario:
- Agregar números a una lista.
- Elegir el tipo de dato numérico:
  - int
  - double
  - float
  - decimal
- Realizar operaciones matemáticas:
  - suma
  - resta
  - multiplicación
  - división
- Manejar errores comunes mediante excepciones.

El programa fue desarrollado con el objetivo de aplicar conceptos importantes del lenguaje C# como programación genérica, delegados y manejo de excepciones.

---

# Objetivo del Proyecto

Desarrollar una aplicación flexible que permita trabajar con diferentes tipos de datos numéricos utilizando una misma estructura de código, aplicando:
- Genéricos
- Delegados
- Excepciones

---

# Funcionalidades

- Agregar números dinámicamente a una lista.
- Mostrar los números almacenados.
- Ejecutar operaciones matemáticas sobre todos los elementos de la lista.
- Validar entradas del usuario.
- Detectar errores como divisiones entre cero o listas insuficientes.

---

# Explicación de los Métodos Utilizados

## AgregarNumero(T numero)

```csharp
public void AgregarNumero(T numero)
```
Este método agrega un número a la lista genérica.
---

## MostrarNumeros()

```csharp
public void MostrarNumeros()
```
Muestra todos los números almacenados en la lista.
---

## EjecutarOperacion(Operacion<T> operacion)

```csharp
public T EjecutarOperacion(Operacion<T> operacion)
```
Ejecuta una operación matemática utilizando un delegado.

Este método:
- Verifica que existan al menos dos números.
- Recorre la lista.
- Aplica la operación seleccionada.
---

## Métodos Matemáticos

### Sumar

```csharp
static T Sumar<T>(T a, T b)
```
Realiza la suma de dos números.
---

### Restar

```csharp
static T Restar<T>(T a, T b)
```
Realiza la resta de dos números.
---

### Multiplicar

```csharp
static T Multiplicar<T>(T a, T b)
```
Realiza la multiplicación de dos números.
---

### Dividir

```csharp
static T Dividir<T>(T a, T b)
```
Realiza la división de dos números y valida división entre cero.
---

# Uso de Genéricos

El programa utiliza genéricos mediante la clase:

```csharp
CalculadoraGenerica<T>
```
Esto permite que la misma clase funcione con distintos tipos de datos numéricos sin duplicar código.

Ejemplos:
- `CalculadoraGenerica<int>`
- `CalculadoraGenerica<double>`
- `CalculadoraGenerica<float>`
- `CalculadoraGenerica<decimal>`

Los números son almacenados en una lista genérica:

```csharp
List<T>
```

---

# Uso de Delegados

Se implementa el delegado:

```csharp
public delegate T Operacion<T>(T a, T b);
```

El delegado representa cualquier operación matemática que:
- recibe dos parámetros,
- devuelve un resultado.

Las operaciones matemáticas son enviadas dinámicamente al método `EjecutarOperacion()`.

---

# Uso de dynamic

El código utiliza `dynamic` para permitir operaciones matemáticas con tipos genéricos.

Ejemplo:

```csharp
(dynamic)a + (dynamic)b
```

Esto permite que los operadores matemáticos funcionen correctamente con distintos tipos numéricos.

---

# Excepciones Manejadas

## FormatException

Se produce cuando el usuario ingresa un valor no numérico.

Ejemplo:

```text
Ingrese un número: hola
```

---

## DivideByZeroException

Se produce cuando se intenta dividir entre cero.

El programa muestra un mensaje indicando el error.

---

## ListaInsuficienteException

Es una excepción personalizada que ocurre cuando la lista tiene menos de dos elementos y se intenta realizar una operación matemática.

---

## Exception

Captura cualquier error inesperado que pueda ocurrir durante la ejecución.
