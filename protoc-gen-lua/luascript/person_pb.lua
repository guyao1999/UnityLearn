-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf"
module('person_pb')


local PERSON = protobuf.Descriptor();
local PERSON_ID_FIELD = protobuf.FieldDescriptor();
local PERSON_NAME_FIELD = protobuf.FieldDescriptor();
local PERSON_EMAIL_FIELD = protobuf.FieldDescriptor();
local PHONE = protobuf.Descriptor();
local PHONE_PHONE_TYPE = protobuf.EnumDescriptor();
local PHONE_PHONE_TYPE_MOBILE_ENUM = protobuf.EnumValueDescriptor();
local PHONE_PHONE_TYPE_HOME_ENUM = protobuf.EnumValueDescriptor();
local PHONE_NUM_FIELD = protobuf.FieldDescriptor();
local PHONE_TYPE_FIELD = protobuf.FieldDescriptor();
local PHONE_PHONES_FIELD = protobuf.FieldDescriptor();
local TESTB = protobuf.Descriptor();
local TESTB_AA_FIELD = protobuf.FieldDescriptor();
local TESTB_BB_FIELD = protobuf.FieldDescriptor();
local TESTB_CC_FIELD = protobuf.FieldDescriptor();
local TESTA = protobuf.Descriptor();
local TESTA_ID_FIELD = protobuf.FieldDescriptor();
local TESTA_NAME_FIELD = protobuf.FieldDescriptor();
local TESTA_YEAR_FIELD = protobuf.FieldDescriptor();
local TESTA_NETTYPE_FIELD = protobuf.FieldDescriptor();
local TESTC = protobuf.Descriptor();
local TESTC_TESTA_FIELD = protobuf.FieldDescriptor();
local TESTC_TESTB_FIELD = protobuf.FieldDescriptor();
local TESTD = protobuf.Descriptor();
local TESTD_DDDD_FIELD = protobuf.FieldDescriptor();
local TESTE = protobuf.Descriptor();
local TESTE_TESTD_FIELD = protobuf.FieldDescriptor();

PERSON_ID_FIELD.name = "id"
PERSON_ID_FIELD.full_name = ".Person.id"
PERSON_ID_FIELD.number = 1
PERSON_ID_FIELD.index = 0
PERSON_ID_FIELD.label = 2
PERSON_ID_FIELD.has_default_value = false
PERSON_ID_FIELD.default_value = 0
PERSON_ID_FIELD.type = 5
PERSON_ID_FIELD.cpp_type = 1

PERSON_NAME_FIELD.name = "name"
PERSON_NAME_FIELD.full_name = ".Person.name"
PERSON_NAME_FIELD.number = 2
PERSON_NAME_FIELD.index = 1
PERSON_NAME_FIELD.label = 2
PERSON_NAME_FIELD.has_default_value = false
PERSON_NAME_FIELD.default_value = ""
PERSON_NAME_FIELD.type = 9
PERSON_NAME_FIELD.cpp_type = 9

PERSON_EMAIL_FIELD.name = "email"
PERSON_EMAIL_FIELD.full_name = ".Person.email"
PERSON_EMAIL_FIELD.number = 3
PERSON_EMAIL_FIELD.index = 2
PERSON_EMAIL_FIELD.label = 1
PERSON_EMAIL_FIELD.has_default_value = false
PERSON_EMAIL_FIELD.default_value = ""
PERSON_EMAIL_FIELD.type = 9
PERSON_EMAIL_FIELD.cpp_type = 9

PERSON.name = "Person"
PERSON.full_name = ".Person"
PERSON.nested_types = {}
PERSON.enum_types = {}
PERSON.fields = {PERSON_ID_FIELD, PERSON_NAME_FIELD, PERSON_EMAIL_FIELD}
PERSON.is_extendable = true
PERSON.extensions = {}
PHONE_PHONE_TYPE_MOBILE_ENUM.name = "MOBILE"
PHONE_PHONE_TYPE_MOBILE_ENUM.index = 0
PHONE_PHONE_TYPE_MOBILE_ENUM.number = 1
PHONE_PHONE_TYPE_HOME_ENUM.name = "HOME"
PHONE_PHONE_TYPE_HOME_ENUM.index = 1
PHONE_PHONE_TYPE_HOME_ENUM.number = 2
PHONE_PHONE_TYPE.name = "PHONE_TYPE"
PHONE_PHONE_TYPE.full_name = ".Phone.PHONE_TYPE"
PHONE_PHONE_TYPE.values = {PHONE_PHONE_TYPE_MOBILE_ENUM,PHONE_PHONE_TYPE_HOME_ENUM}
PHONE_NUM_FIELD.name = "num"
PHONE_NUM_FIELD.full_name = ".Phone.num"
PHONE_NUM_FIELD.number = 1
PHONE_NUM_FIELD.index = 0
PHONE_NUM_FIELD.label = 1
PHONE_NUM_FIELD.has_default_value = false
PHONE_NUM_FIELD.default_value = ""
PHONE_NUM_FIELD.type = 9
PHONE_NUM_FIELD.cpp_type = 9

PHONE_TYPE_FIELD.name = "type"
PHONE_TYPE_FIELD.full_name = ".Phone.type"
PHONE_TYPE_FIELD.number = 2
PHONE_TYPE_FIELD.index = 1
PHONE_TYPE_FIELD.label = 1
PHONE_TYPE_FIELD.has_default_value = false
PHONE_TYPE_FIELD.default_value = nil
PHONE_TYPE_FIELD.enum_type = PHONE_PHONE_TYPE
PHONE_TYPE_FIELD.type = 14
PHONE_TYPE_FIELD.cpp_type = 8

PHONE_PHONES_FIELD.name = "phones"
PHONE_PHONES_FIELD.full_name = ".Phone.phones"
PHONE_PHONES_FIELD.number = 10
PHONE_PHONES_FIELD.index = 0
PHONE_PHONES_FIELD.label = 3
PHONE_PHONES_FIELD.has_default_value = false
PHONE_PHONES_FIELD.default_value = {}
PHONE_PHONES_FIELD.message_type = PHONE
PHONE_PHONES_FIELD.type = 11
PHONE_PHONES_FIELD.cpp_type = 10

PHONE.name = "Phone"
PHONE.full_name = ".Phone"
PHONE.nested_types = {}
PHONE.enum_types = {PHONE_PHONE_TYPE}
PHONE.fields = {PHONE_NUM_FIELD, PHONE_TYPE_FIELD}
PHONE.is_extendable = false
PHONE.extensions = {PHONE_PHONES_FIELD}
TESTB_AA_FIELD.name = "aa"
TESTB_AA_FIELD.full_name = ".TestB.aa"
TESTB_AA_FIELD.number = 1
TESTB_AA_FIELD.index = 0
TESTB_AA_FIELD.label = 2
TESTB_AA_FIELD.has_default_value = false
TESTB_AA_FIELD.default_value = 0
TESTB_AA_FIELD.type = 13
TESTB_AA_FIELD.cpp_type = 3

TESTB_BB_FIELD.name = "bb"
TESTB_BB_FIELD.full_name = ".TestB.bb"
TESTB_BB_FIELD.number = 2
TESTB_BB_FIELD.index = 1
TESTB_BB_FIELD.label = 1
TESTB_BB_FIELD.has_default_value = false
TESTB_BB_FIELD.default_value = 0
TESTB_BB_FIELD.type = 13
TESTB_BB_FIELD.cpp_type = 3

TESTB_CC_FIELD.name = "cc"
TESTB_CC_FIELD.full_name = ".TestB.cc"
TESTB_CC_FIELD.number = 3
TESTB_CC_FIELD.index = 2
TESTB_CC_FIELD.label = 2
TESTB_CC_FIELD.has_default_value = false
TESTB_CC_FIELD.default_value = ""
TESTB_CC_FIELD.type = 9
TESTB_CC_FIELD.cpp_type = 9

TESTB.name = "TestB"
TESTB.full_name = ".TestB"
TESTB.nested_types = {}
TESTB.enum_types = {}
TESTB.fields = {TESTB_AA_FIELD, TESTB_BB_FIELD, TESTB_CC_FIELD}
TESTB.is_extendable = false
TESTB.extensions = {}
TESTA_ID_FIELD.name = "id"
TESTA_ID_FIELD.full_name = ".TestA.id"
TESTA_ID_FIELD.number = 1
TESTA_ID_FIELD.index = 0
TESTA_ID_FIELD.label = 2
TESTA_ID_FIELD.has_default_value = false
TESTA_ID_FIELD.default_value = 0
TESTA_ID_FIELD.type = 13
TESTA_ID_FIELD.cpp_type = 3

TESTA_NAME_FIELD.name = "name"
TESTA_NAME_FIELD.full_name = ".TestA.name"
TESTA_NAME_FIELD.number = 2
TESTA_NAME_FIELD.index = 1
TESTA_NAME_FIELD.label = 1
TESTA_NAME_FIELD.has_default_value = false
TESTA_NAME_FIELD.default_value = 0
TESTA_NAME_FIELD.type = 13
TESTA_NAME_FIELD.cpp_type = 3

TESTA_YEAR_FIELD.name = "year"
TESTA_YEAR_FIELD.full_name = ".TestA.year"
TESTA_YEAR_FIELD.number = 3
TESTA_YEAR_FIELD.index = 2
TESTA_YEAR_FIELD.label = 2
TESTA_YEAR_FIELD.has_default_value = false
TESTA_YEAR_FIELD.default_value = ""
TESTA_YEAR_FIELD.type = 9
TESTA_YEAR_FIELD.cpp_type = 9

TESTA_NETTYPE_FIELD.name = "nettype"
TESTA_NETTYPE_FIELD.full_name = ".TestA.nettype"
TESTA_NETTYPE_FIELD.number = 4
TESTA_NETTYPE_FIELD.index = 3
TESTA_NETTYPE_FIELD.label = 1
TESTA_NETTYPE_FIELD.has_default_value = false
TESTA_NETTYPE_FIELD.default_value = 0
TESTA_NETTYPE_FIELD.type = 13
TESTA_NETTYPE_FIELD.cpp_type = 3

TESTA.name = "TestA"
TESTA.full_name = ".TestA"
TESTA.nested_types = {}
TESTA.enum_types = {}
TESTA.fields = {TESTA_ID_FIELD, TESTA_NAME_FIELD, TESTA_YEAR_FIELD, TESTA_NETTYPE_FIELD}
TESTA.is_extendable = false
TESTA.extensions = {}
TESTC_TESTA_FIELD.name = "testa"
TESTC_TESTA_FIELD.full_name = ".TestC.testa"
TESTC_TESTA_FIELD.number = 1
TESTC_TESTA_FIELD.index = 0
TESTC_TESTA_FIELD.label = 2
TESTC_TESTA_FIELD.has_default_value = false
TESTC_TESTA_FIELD.default_value = nil
TESTC_TESTA_FIELD.message_type = TESTA
TESTC_TESTA_FIELD.type = 11
TESTC_TESTA_FIELD.cpp_type = 10

TESTC_TESTB_FIELD.name = "testb"
TESTC_TESTB_FIELD.full_name = ".TestC.testb"
TESTC_TESTB_FIELD.number = 2
TESTC_TESTB_FIELD.index = 1
TESTC_TESTB_FIELD.label = 2
TESTC_TESTB_FIELD.has_default_value = false
TESTC_TESTB_FIELD.default_value = nil
TESTC_TESTB_FIELD.message_type = TESTB
TESTC_TESTB_FIELD.type = 11
TESTC_TESTB_FIELD.cpp_type = 10

TESTC.name = "TestC"
TESTC.full_name = ".TestC"
TESTC.nested_types = {}
TESTC.enum_types = {}
TESTC.fields = {TESTC_TESTA_FIELD, TESTC_TESTB_FIELD}
TESTC.is_extendable = false
TESTC.extensions = {}
TESTD_DDDD_FIELD.name = "dddd"
TESTD_DDDD_FIELD.full_name = ".TestD.dddd"
TESTD_DDDD_FIELD.number = 1
TESTD_DDDD_FIELD.index = 0
TESTD_DDDD_FIELD.label = 2
TESTD_DDDD_FIELD.has_default_value = false
TESTD_DDDD_FIELD.default_value = 0
TESTD_DDDD_FIELD.type = 13
TESTD_DDDD_FIELD.cpp_type = 3

TESTD.name = "TestD"
TESTD.full_name = ".TestD"
TESTD.nested_types = {}
TESTD.enum_types = {}
TESTD.fields = {TESTD_DDDD_FIELD}
TESTD.is_extendable = false
TESTD.extensions = {}
TESTE_TESTD_FIELD.name = "testd"
TESTE_TESTD_FIELD.full_name = ".TestE.testd"
TESTE_TESTD_FIELD.number = 1
TESTE_TESTD_FIELD.index = 0
TESTE_TESTD_FIELD.label = 2
TESTE_TESTD_FIELD.has_default_value = false
TESTE_TESTD_FIELD.default_value = nil
TESTE_TESTD_FIELD.message_type = TESTD
TESTE_TESTD_FIELD.type = 11
TESTE_TESTD_FIELD.cpp_type = 10

TESTE.name = "TestE"
TESTE.full_name = ".TestE"
TESTE.nested_types = {}
TESTE.enum_types = {}
TESTE.fields = {TESTE_TESTD_FIELD}
TESTE.is_extendable = false
TESTE.extensions = {}

Person = protobuf.Message(PERSON)
Phone = protobuf.Message(PHONE)
TestA = protobuf.Message(TESTA)
TestB = protobuf.Message(TESTB)
TestC = protobuf.Message(TESTC)
TestD = protobuf.Message(TESTD)
TestE = protobuf.Message(TESTE)

Person.RegisterExtension(PHONE_PHONES_FIELD)