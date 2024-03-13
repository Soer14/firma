# Firma
Plan gry
Stworzę aplikację do prowadzenia małej firmy
Zakres funkcjonalności:

- Ewidencja klientów - `Customer`
- Ewidencja faktur sprzedaży
- Produkty i cennik
- Zlecenia i zadania - `Order`, `Task`
- Ewidencja faktur kosztowych
- Powiązanie kosztów że zleceniami
- Wysyłanie faktur do KSEF
- Pobieranie faktur z KSEF
- Rozponawanie faktur i paragonów zakupowych
- Drukowanie paragonu na drukarce fiskalnej
- Obsługa paragonów elektronicznych





Format MarkDown

** Struktura bazy

```mermaid
---
title: Firma
---
erDiagram
  Product }|..|{ Tags : uses
  Product ||--o{ PriceList : has
  Customer }|..|{ CustomerAddress : uses
  Customer ||--o{ PurchaseInvoice : register
  Customer ||--o{ SaleInvoice : generates
  Customer ||--o{ Order : places
  PurchaseInvoice ||--o{ PurchaseInvoiceItem : includes
  SaleInvoice ||--o{  SaleInvoiceItem : includes
  PurchaseInvoiceItem ||--o{ Product : has
  SaleInvoiceItem ||--o{ Product : has
 
  Order ||--o{ Order : consists
  Order ||--o{ Task : includes
  Order ||--o{ Task : includes
```



** Struktura klas

** Dodatkowe linki

 https://vimeo.com/669139136?share=copy  Definiowanie faktury w report designer
