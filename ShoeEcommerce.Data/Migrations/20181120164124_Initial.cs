using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillStates",
                columns: table => new
                {
                    idState = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStates", x => x.idState);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    idCategory = table.Column<string>(maxLength: 10, nullable: false),
                    nameCategory = table.Column<string>(nullable: false),
                    link_imageCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    idCustomer = table.Column<string>(maxLength: 10, nullable: false),
                    lstname = table.Column<string>(maxLength: 50, nullable: false),
                    fstname = table.Column<string>(maxLength: 50, nullable: false),
                    phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.idCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    idMerchant = table.Column<string>(maxLength: 10, nullable: false),
                    lstname = table.Column<string>(maxLength: 20, nullable: false),
                    fstname = table.Column<string>(maxLength: 20, nullable: false),
                    storename = table.Column<string>(maxLength: 60, nullable: false),
                    phone = table.Column<string>(nullable: false),
                    website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.idMerchant);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    idPosition = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    width = table.Column<float>(nullable: false),
                    height = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.idPosition);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    idPost = table.Column<string>(maxLength: 10, nullable: false),
                    idAcc = table.Column<string>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    curRank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.idPost);
                });

            migrationBuilder.CreateTable(
                name: "Repositories",
                columns: table => new
                {
                    idRepository = table.Column<string>(maxLength: 10, nullable: false),
                    name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    Stt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositories", x => x.idRepository);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    idProduct = table.Column<string>(maxLength: 10, nullable: false),
                    nameProduct = table.Column<string>(nullable: true),
                    code = table.Column<string>(maxLength: 100, nullable: true),
                    description = table.Column<string>(maxLength: 100, nullable: true),
                    brand = table.Column<string>(maxLength: 20, nullable: true),
                    idCategory = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.idProduct);
                    table.ForeignKey(
                        name: "FK_Products_Categories_idCategory",
                        column: x => x.idCategory,
                        principalTable: "Categories",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    idAccount = table.Column<string>(maxLength: 10, nullable: false),
                    username = table.Column<string>(maxLength: 30, nullable: false),
                    passwd = table.Column<string>(maxLength: 30, nullable: false),
                    avt_path = table.Column<string>(nullable: false),
                    rate = table.Column<int>(nullable: false),
                    rankVip = table.Column<int>(nullable: false),
                    IdMerchant = table.Column<string>(maxLength: 10, nullable: false),
                    idCustomer = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.idAccount);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_idCustomer",
                        column: x => x.idCustomer,
                        principalTable: "Customers",
                        principalColumn: "idCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Merchants_IdMerchant",
                        column: x => x.IdMerchant,
                        principalTable: "Merchants",
                        principalColumn: "idMerchant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link_ImgStores",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 10, nullable: false),
                    path = table.Column<string>(nullable: false),
                    idMerchant = table.Column<string>(maxLength: 10, nullable: true),
                    CustomeridCustomer = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_ImgStores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Link_ImgStores_Customers_CustomeridCustomer",
                        column: x => x.CustomeridCustomer,
                        principalTable: "Customers",
                        principalColumn: "idCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_ImgStores_Merchants_idMerchant",
                        column: x => x.idMerchant,
                        principalTable: "Merchants",
                        principalColumn: "idMerchant",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExportForms",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 10, nullable: false),
                    creat_date = table.Column<DateTime>(nullable: false),
                    idRepository = table.Column<string>(maxLength: 10, nullable: false),
                    total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportForms", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExportForms_Repositories_idRepository",
                        column: x => x.idRepository,
                        principalTable: "Repositories",
                        principalColumn: "idRepository",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportForms",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 10, nullable: false),
                    creat_date = table.Column<DateTime>(nullable: false),
                    idRepository = table.Column<string>(maxLength: 10, nullable: false),
                    total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportForms", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImportForms_Repositories_idRepository",
                        column: x => x.idRepository,
                        principalTable: "Repositories",
                        principalColumn: "idRepository",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    idShow = table.Column<string>(maxLength: 10, nullable: false),
                    idPost = table.Column<string>(maxLength: 10, nullable: false),
                    idProduct = table.Column<string>(maxLength: 10, nullable: false),
                    Intro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.idShow);
                    table.ForeignKey(
                        name: "FK_Shows_Posts_idPost",
                        column: x => x.idPost,
                        principalTable: "Posts",
                        principalColumn: "idPost",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    add_Info = table.Column<string>(maxLength: 100, nullable: false),
                    subDistrict = table.Column<string>(maxLength: 20, nullable: false),
                    District_town = table.Column<string>(maxLength: 20, nullable: false),
                    City_Provine = table.Column<string>(maxLength: 20, nullable: false),
                    idAccount = table.Column<string>(maxLength: 10, nullable: false),
                    Addressid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Addresses_Addresses_Addressid",
                        column: x => x.Addressid,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Accounts_idAccount",
                        column: x => x.idAccount,
                        principalTable: "Accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    idAdvertisement = table.Column<string>(maxLength: 10, nullable: false),
                    creat_date = table.Column<DateTime>(nullable: false),
                    expire = table.Column<int>(nullable: false),
                    idAccount = table.Column<string>(maxLength: 10, nullable: false),
                    position = table.Column<int>(nullable: false),
                    PositionidPosition = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.idAdvertisement);
                    table.ForeignKey(
                        name: "FK_Advertisements_Accounts_idAccount",
                        column: x => x.idAccount,
                        principalTable: "Accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisements_Position_PositionidPosition",
                        column: x => x.PositionidPosition,
                        principalTable: "Position",
                        principalColumn: "idPosition",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistorySearches",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    keyword = table.Column<string>(nullable: true),
                    idAcc = table.Column<string>(maxLength: 10, nullable: false),
                    AccountidAccount = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorySearches", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistorySearches_Accounts_AccountidAccount",
                        column: x => x.AccountidAccount,
                        principalTable: "Accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    idproductDetail = table.Column<string>(maxLength: 10, nullable: false),
                    idProduct = table.Column<string>(maxLength: 10, nullable: false),
                    price = table.Column<double>(nullable: false),
                    creat_date = table.Column<DateTime>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    fee = table.Column<float>(nullable: false),
                    IdAcc = table.Column<string>(maxLength: 10, nullable: false),
                    AccountidAccount = table.Column<string>(maxLength: 10, nullable: true),
                    IdRepository = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.idproductDetail);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Accounts_AccountidAccount",
                        column: x => x.AccountidAccount,
                        principalTable: "Accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Repositories_IdRepository",
                        column: x => x.IdRepository,
                        principalTable: "Repositories",
                        principalColumn: "idRepository",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemEplists",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idProduct = table.Column<int>(nullable: false),
                    idEpform = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    ProductidProduct = table.Column<string>(maxLength: 10, nullable: true),
                    ExportFormid = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEplists", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItemEplists_ExportForms_ExportFormid",
                        column: x => x.ExportFormid,
                        principalTable: "ExportForms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemEplists_Products_ProductidProduct",
                        column: x => x.ProductidProduct,
                        principalTable: "Products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemIplists",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idProduct = table.Column<string>(maxLength: 10, nullable: false),
                    idIpForm = table.Column<string>(maxLength: 10, nullable: false),
                    count = table.Column<int>(nullable: false),
                    ImportFormid = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemIplists", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItemIplists_Products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemIplists_ImportForms_ImportFormid",
                        column: x => x.ImportFormid,
                        principalTable: "ImportForms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 10, nullable: false),
                    email = table.Column<string>(nullable: true),
                    IdAccount = table.Column<string>(maxLength: 10, nullable: true),
                    Addressid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.id);
                    table.ForeignKey(
                        name: "FK_Emails_Addresses_Addressid",
                        column: x => x.Addressid,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    idOrder = table.Column<string>(maxLength: 10, nullable: false),
                    creat_date = table.Column<DateTime>(nullable: false),
                    idStt = table.Column<int>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    IdSaleAcc = table.Column<string>(maxLength: 10, nullable: false),
                    idBuyAcc = table.Column<string>(maxLength: 10, nullable: false),
                    BillStateidState = table.Column<int>(nullable: true),
                    AccountidAccount = table.Column<string>(maxLength: 10, nullable: true),
                    Addressid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.idOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountidAccount",
                        column: x => x.AccountidAccount,
                        principalTable: "Accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_Addressid",
                        column: x => x.Addressid,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_BillStates_BillStateidState",
                        column: x => x.BillStateidState,
                        principalTable: "BillStates",
                        principalColumn: "idState",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageProducts",
                columns: table => new
                {
                    idImage = table.Column<string>(maxLength: 10, nullable: false),
                    link_Image = table.Column<string>(maxLength: 40, nullable: true),
                    idproductDetail = table.Column<int>(nullable: false),
                    productDetailidproductDetail = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProducts", x => x.idImage);
                    table.ForeignKey(
                        name: "FK_ImageProducts_ProductDetails_productDetailidproductDetail",
                        column: x => x.productDetailidproductDetail,
                        principalTable: "ProductDetails",
                        principalColumn: "idproductDetail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrderLists",
                columns: table => new
                {
                    idList = table.Column<string>(maxLength: 10, nullable: false),
                    idProduct = table.Column<string>(maxLength: 10, nullable: false),
                    idOrder = table.Column<string>(maxLength: 10, nullable: false),
                    count = table.Column<int>(nullable: false),
                    avgRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrderLists", x => x.idList);
                    table.ForeignKey(
                        name: "FK_ItemOrderLists_Orders_idOrder",
                        column: x => x.idOrder,
                        principalTable: "Orders",
                        principalColumn: "idOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrderLists_Products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rateValue = table.Column<int>(nullable: false),
                    Cmt = table.Column<string>(nullable: false),
                    idItemOrderList = table.Column<int>(nullable: false),
                    ItemOrderListidList = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ratings_ItemOrderLists_ItemOrderListidList",
                        column: x => x.ItemOrderListidList,
                        principalTable: "ItemOrderLists",
                        principalColumn: "idList",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_idCustomer",
                table: "Accounts",
                column: "idCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdMerchant",
                table: "Accounts",
                column: "IdMerchant");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Addressid",
                table: "Addresses",
                column: "Addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_idAccount",
                table: "Addresses",
                column: "idAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_idAccount",
                table: "Advertisements",
                column: "idAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_PositionidPosition",
                table: "Advertisements",
                column: "PositionidPosition");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_Addressid",
                table: "Emails",
                column: "Addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_IdAccount",
                table: "Emails",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_ExportForms_idRepository",
                table: "ExportForms",
                column: "idRepository");

            migrationBuilder.CreateIndex(
                name: "IX_HistorySearches_AccountidAccount",
                table: "HistorySearches",
                column: "AccountidAccount");

            migrationBuilder.CreateIndex(
                name: "IX_ImageProducts_productDetailidproductDetail",
                table: "ImageProducts",
                column: "productDetailidproductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_ImportForms_idRepository",
                table: "ImportForms",
                column: "idRepository");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEplists_ExportFormid",
                table: "ItemEplists",
                column: "ExportFormid");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEplists_ProductidProduct",
                table: "ItemEplists",
                column: "ProductidProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ItemIplists_idProduct",
                table: "ItemIplists",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ItemIplists_ImportFormid",
                table: "ItemIplists",
                column: "ImportFormid");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrderLists_idOrder",
                table: "ItemOrderLists",
                column: "idOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrderLists_idProduct",
                table: "ItemOrderLists",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Link_ImgStores_CustomeridCustomer",
                table: "Link_ImgStores",
                column: "CustomeridCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Link_ImgStores_idMerchant",
                table: "Link_ImgStores",
                column: "idMerchant");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountidAccount",
                table: "Orders",
                column: "AccountidAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Addressid",
                table: "Orders",
                column: "Addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillStateidState",
                table: "Orders",
                column: "BillStateidState");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_AccountidAccount",
                table: "ProductDetails",
                column: "AccountidAccount");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_idProduct",
                table: "ProductDetails",
                column: "idProduct",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IdRepository",
                table: "ProductDetails",
                column: "IdRepository");

            migrationBuilder.CreateIndex(
                name: "IX_Products_idCategory",
                table: "Products",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ItemOrderListidList",
                table: "Ratings",
                column: "ItemOrderListidList");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_idPost",
                table: "Shows",
                column: "idPost");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_idProduct",
                table: "Shows",
                column: "idProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "HistorySearches");

            migrationBuilder.DropTable(
                name: "ImageProducts");

            migrationBuilder.DropTable(
                name: "ItemEplists");

            migrationBuilder.DropTable(
                name: "ItemIplists");

            migrationBuilder.DropTable(
                name: "Link_ImgStores");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "ExportForms");

            migrationBuilder.DropTable(
                name: "ImportForms");

            migrationBuilder.DropTable(
                name: "ItemOrderLists");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Repositories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BillStates");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Merchants");
        }
    }
}
