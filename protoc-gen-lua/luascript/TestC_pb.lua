-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf"
local TestA_pb = require("TestA_pb")
local TestB_pb = require("TestB_pb")
module('TestC_pb')


local TESTC = protobuf.Descriptor();
local TESTC_TESTA_FIELD = protobuf.FieldDescriptor();
local TESTC_TESTB_FIELD = protobuf.FieldDescriptor();
local TESTD = protobuf.Descriptor();
local TESTD_DDDD_FIELD = protobuf.FieldDescriptor();
local TESTE = protobuf.Descriptor();
local TESTE_TESTD_FIELD = protobuf.FieldDescriptor();

TESTC_TESTA_FIELD.name = "testa"
TESTC_TESTA_FIELD.full_name = ".Google.TestC.testa"
TESTC_TESTA_FIELD.number = 1
TESTC_TESTA_FIELD.index = 0
TESTC_TESTA_FIELD.label = 2
TESTC_TESTA_FIELD.has_default_value = false
TESTC_TESTA_FIELD.default_value = nil
TESTC_TESTA_FIELD.message_type = TESTA_PB_TESTA
TESTC_TESTA_FIELD.type = 11
TESTC_TESTA_FIELD.cpp_type = 10

TESTC_TESTB_FIELD.name = "testb"
TESTC_TESTB_FIELD.full_name = ".Google.TestC.testb"
TESTC_TESTB_FIELD.number = 2
TESTC_TESTB_FIELD.index = 1
TESTC_TESTB_FIELD.label = 2
TESTC_TESTB_FIELD.has_default_value = false
TESTC_TESTB_FIELD.default_value = nil
TESTC_TESTB_FIELD.message_type = TESTB_PB_TESTB
TESTC_TESTB_FIELD.type = 11
TESTC_TESTB_FIELD.cpp_type = 10

TESTC.name = "TestC"
TESTC.full_name = ".Google.TestC"
TESTC.nested_types = {}
TESTC.enum_types = {}
TESTC.fields = {TESTC_TESTA_FIELD, TESTC_TESTB_FIELD}
TESTC.is_extendable = false
TESTC.extensions = {}
TESTD_DDDD_FIELD.name = "dddd"
TESTD_DDDD_FIELD.full_name = ".Google.TestD.dddd"
TESTD_DDDD_FIELD.number = 1
TESTD_DDDD_FIELD.index = 0
TESTD_DDDD_FIELD.label = 2
TESTD_DDDD_FIELD.has_default_value = false
TESTD_DDDD_FIELD.default_value = 0
TESTD_DDDD_FIELD.type = 13
TESTD_DDDD_FIELD.cpp_type = 3

TESTD.name = "TestD"
TESTD.full_name = ".Google.TestD"
TESTD.nested_types = {}
TESTD.enum_types = {}
TESTD.fields = {TESTD_DDDD_FIELD}
TESTD.is_extendable = false
TESTD.extensions = {}
TESTE_TESTD_FIELD.name = "testd"
TESTE_TESTD_FIELD.full_name = ".Google.TestE.testd"
TESTE_TESTD_FIELD.number = 1
TESTE_TESTD_FIELD.index = 0
TESTE_TESTD_FIELD.label = 2
TESTE_TESTD_FIELD.has_default_value = false
TESTE_TESTD_FIELD.default_value = nil
TESTE_TESTD_FIELD.message_type = TESTD
TESTE_TESTD_FIELD.type = 11
TESTE_TESTD_FIELD.cpp_type = 10

TESTE.name = "TestE"
TESTE.full_name = ".Google.TestE"
TESTE.nested_types = {}
TESTE.enum_types = {}
TESTE.fields = {TESTE_TESTD_FIELD}
TESTE.is_extendable = false
TESTE.extensions = {}

TestC = protobuf.Message(TESTC)
TestD = protobuf.Message(TESTD)
TestE = protobuf.Message(TESTE)

