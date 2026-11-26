                    col.Item()
                        .PaddingTop(15)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(75);
                                columns.RelativeColumn(3);
                                columns.ConstantColumn(50);
                                columns.ConstantColumn(70);
                                columns.ConstantColumn(80);
                            });

                            table.Header(header =>
                            {
                                header.Cell()
                                    .Background("#0EA5E9")
                                    .Padding(5)
                                    .Text("SKU")
                                    .FontColor("#FFFFFF")
                                    .Bold();

                                header.Cell()
                                    .Background("#0EA5E9")
                                    .Padding(5)
                                    .Text("PRODUCTO")
                                    .FontColor("#FFFFFF")
                                    .Bold();

                                header.Cell()
                                    .Background("#0EA5E9")
                                    .Padding(5)
                                    .Text("CANT.")
                                    .FontColor("#FFFFFF")
                                    .Bold();

                                header.Cell()
                                    .Background("#0EA5E9")
                                    .Padding(5)
                                    .Text("P. UNIT.")
                                    .FontColor("#FFFFFF")
                                    .Bold();

                                header.Cell()
                                    .Background("#0EA5E9")
                                    .Padding(5)
                                    .Text("SUBTOTAL")
                                    .FontColor("#FFFFFF")
                                    .Bold();
                            });

                            foreach (var d in p.Detalles)
                            {
                                table.Cell()
                                    .Padding(5)
                                    .Text(d.Sku ?? "");

                                table.Cell()
                                    .Padding(5)
                                    .Text(d.NombreProducto ?? "");

                                table.Cell()
                                    .Padding(5)
                                    .Text(d.Cantidad.ToString());

                                table.Cell()
                                    .Padding(5)
                                    .Text($"S/ {d.PrecioUnitario:N2}");

                                table.Cell()
                                    .Padding(5)
                                    .Text($"S/ {d.SubtotalLinea:N2}");
                            }
                        });

                    // TOTALES
                    col.Item()
                        .PaddingTop(15)
                        .AlignRight()
                        .Text($"Subtotal: S/ {p.Subtotal:N2}");

                    col.Item()
                        .AlignRight()
                        .Text($"IGV (18%): S/ {p.Igv:N2}");

                    col.Item()
                        .AlignRight()
                        .Text($"TOTAL: S/ {p.Total:N2}")
                        .FontSize(14)
                        .Bold()
                        .FontColor("#0EA5E9");
                });

            // PIE
            page.Footer()
                .AlignCenter()
                .Text("Security PRO S.A.C. - Pedido de Venta");
        });
    }).GeneratePdf();
}

    // =========================================================
    // GENERADOR QR
    // =========================================================
    private byte[] GenerarQr(string contenido)
    {
        using var qrGenerator = new QRCodeGenerator();

        using var qrData = qrGenerator.CreateQrCode(
            contenido,
            QRCodeGenerator.ECCLevel.Q
        );

        using var qrCode = new PngByteQRCode(qrData);

        return qrCode.GetGraphic(10);
    }
}
